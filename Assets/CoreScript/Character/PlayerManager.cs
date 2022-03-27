using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using static SenceDataControl;

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

    public struct CurrentLight{
        public Light2D light2d;
        public float brl;
    };
    public CurrentLight currentLight;
        
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
        if (alreadyChocieCharacter[0] && alreadyChocieCharacter[1])
        {
            if (CharacterID == 0)
                SenceLoadManager.instance.LoadSence("Hall", PlayerManager.instance.PlayerCreatVector["Hall"][0]);
            if (CharacterID == 1)
                SenceLoadManager.instance.LoadSence("Hall", PlayerManager.instance.PlayerCreatVector["Hall"][1]);
        }
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

    [PunRPC]
    void LoadSenceAndDestoryPlayer(int id)
    {
        EventManger.instance.TriggerEventListener<int>("DestoryPlayer", id);
    }

    [PunRPC]
    void UpdateDate(string s)
    {
        Debug.Log("开始送Date：" + s);
        SenceDataControl.instance.ReciveDate(s);
    }
    #endregion

    private void SetPlayerCreatVector()
    {
        PlayerCreatVector = new Dictionary<string, List<Vector3>>()
            {
                {"Hall", new List<Vector3>(){new Vector3(3.78f,-2.93f,1),new Vector3(0.79f, -2.91f, 1) } },
                {"Level1",new List<Vector3>(){ new Vector3(-30, -2f, 1),new Vector3(35,-2,1), new Vector3(-15, -2, 1),new Vector3(-20,-2,1) } },
                {"顶楼三角杂货间", new List<Vector3>(){new Vector3(1,-1.5f,1) } },
                {"二楼阳台",new List<Vector3>(){ new Vector3(-8,-3f,1) } },
                {"格瑞实验室",new List<Vector3>(){ new Vector3(0.5f,-1.5f,1), new Vector3(20f, -2f, 1) } },
                {"格瑞房间",new List<Vector3>(){ new Vector3(7,-2f,1) } },
                {"华森特房间",new List<Vector3>(){ new Vector3(-2.7f,-2f,1) } },
                {"三楼浴室",new List<Vector3>(){ new Vector3(-0.25f,-5.5f,1), new Vector3(2.35f, -5.5f, 1) } },
                {"二楼浴室",new List<Vector3>(){ new Vector3(6.89f,-5.52f,1) } }
            };
    }

    public void SetLight_Item(float f,bool b)
    {
        if (currentLight.light2d == null)
        {
            return;
        }
        if (b)
            currentLight.light2d.intensity = f;
        else
            currentLight.light2d.intensity = currentLight.brl;
    }



}
