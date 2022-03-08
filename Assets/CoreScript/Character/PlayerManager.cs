using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviourPun
{
    #region myself
    private int _characterID = -1;
    public int CharacterID { get { return _characterID; } set { _characterID = value; } }

    public Dictionary<string, float> lightDic;

    public Vector3 NextSenceVector = new Vector3();
    #endregion

    #region net
    public string[] PlayerScenes;

    public bool[] alreadyChocieCharacter;
    #endregion

    public Dictionary<string, List<Vector3>> PlayerCreatVector;

    public static PlayerManager instance = null;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    
    
    private void Start()
    {
        PlayerScenes = new string[2];
        lightDic = new Dictionary<string, float>(){ { "level1",0.4f},{ "杂货间",0.4f } };
        alreadyChocieCharacter = new bool[2] {false,false};

        SetPlayerCreatVector();
    }


    #region PunRPC Method
    [PunRPC]
    void OtherPlayerChoice(int id)
    {
        Debug.Log("有玩家选择了角色");
        alreadyChocieCharacter[id] = true;
        if(alreadyChocieCharacter[0]&&alreadyChocieCharacter[1])
            SenceLoadManager.instance.LoadSence("Hall", PlayerManager.instance.PlayerCreatVector["Hall"][0]);
    }

    [PunRPC]
    void SetLight(string s,float f)
    {
        if(lightDic.ContainsKey(s))
        {
            lightDic[s] = f;
            EventManger.instance.TriggerEventListener<string,float>("Light",s,f);
        }
    }
    
    [PunRPC]
    void SetPlayerSences(int i,string s)
    {
        PlayerScenes[i] = s;
    }

    #endregion

    private void SetPlayerCreatVector()
    {
        PlayerCreatVector = new Dictionary<string, List<Vector3>>()
            {
                {"Hall", new List<Vector3>(){new Vector3(3,-3.8f,1) } },
                {"Level1",new List<Vector3>(){ new Vector3(-30, -2, 1),new Vector3(35,-2,1) } },
                {"顶楼三角杂货间", new List<Vector3>(){new Vector3(1,-2,1) } },
                {"二楼阳台",new List<Vector3>(){ new Vector3(-8,-3.5f,1) } },
                {"格瑞实验室",new List<Vector3>(){ new Vector3(0.5f,-2f,1) } }
            };
    }
}
