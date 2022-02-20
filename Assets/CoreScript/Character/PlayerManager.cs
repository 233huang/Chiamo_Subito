using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun
{
    public int PlyaerID{ get; set; }
    public string PlyaerName { get; set; }

    private int _characterID = -1;
    public int CharacterID { get { return _characterID; } set { _characterID = value; } }

    private int _otherCharacterID = -1;
    public int OtherCharacterID { 
        get {
            return _otherCharacterID;
        } 
        set {
            _otherCharacterID = value;
            EventManger.instance.TriggerEventListener<int>("OtherPlayerChoice", value);
        } 
    }

    public bool[] alreadyChocieCharacter;

    public static PlayerManager instance = null;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        alreadyChocieCharacter = new bool[2] {false,false};
    }
    [PunRPC]
    void OtherPlayerChoice(int id)
    {
        Debug.Log("有其它玩家选择了角色");
        OtherCharacterID = id;
        //alreadyChocieCharacter[id] = true;
    }
}
