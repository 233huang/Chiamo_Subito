using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviourPun
{
    #region myself
    public int PlyaerID{ get; set; }
    public string PlyaerName { get; set; }

    private int _characterID = -1;
    public int CharacterID { get { return _characterID; } set { _characterID = value; } }

    public Dictionary<string, float> lightDic;
    #endregion

    #region other
    /*private int _otherCharacterID = -1;
    public int OtherCharacterID { 
        get {
            return _otherCharacterID;
        } 
        set {
            _otherCharacterID = value;
            EventManger.instance.TriggerEventListener<int>("OtherPlayerChoice", value);
        } 
    }*/

    public string[] PlayerScenes;
    #endregion

    public bool[] alreadyChocieCharacter;

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
    }


    #region PunRPC Method
    [PunRPC]
    void OtherPlayerChoice(int id)
    {
        Debug.Log("有其它玩家选择了角色");
        alreadyChocieCharacter[id] = true;
        if(alreadyChocieCharacter[0]&&alreadyChocieCharacter[1])
            PhotonNetwork.LoadLevel("Hall");
    }

    [PunRPC]
    void SetLight(string s,float f)
    {
        if(lightDic.ContainsKey(s))
        {
            lightDic[s] = f;
            EventManger.instance.TriggerEventListener<string,float>("Light",s,f);
        }
        else
        {
            Debug.LogWarning("???");
        }
    }
    
    [PunRPC]
    void SetPlayerSences(int i,string s)
    {
        PlayerScenes[i] = s;
    }

    /*[PunRPC]
    void Role_synchron()
    {
        EventManger.instance.TriggerEventListener("Role_synchron");
    }*/
    #endregion
}
