using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetLuncher : MonoBehaviourPunCallbacks
{
    //public InputField SetName;
    public InputField SetRoom;
    public GameObject StartBtn;
    public Text waiting;
    public Text please;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    /*public void CreatName()
    {
        if(SetName!=null)
            PhotonNetwork.NickName = SetName.text;
    }*/
    public void JoinOrCreateRoom()
    {
        Debug.Log("x");
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(SetRoom.text, options, default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("连接上了！");
        SetRoom.gameObject.SetActive(true);
        StartBtn.gameObject.SetActive(true);
        please.gameObject.SetActive(true);
        waiting.text = "加 载 中 . . .";
        waiting.gameObject.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Character");//进入场景
    }
}
