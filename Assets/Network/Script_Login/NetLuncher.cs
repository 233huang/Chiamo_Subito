using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Video;

public class NetLuncher : MonoBehaviourPunCallbacks
{
    public VideoPlayer videoPlayer;
    public GameObject luncherModule;

    public InputField SetRoom;
    public GameObject EnterGame;
    public Text waiting;
    public GameObject StartBtn;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += VideoCallBack;
        Connect();
        SetRoom.onValueChanged.AddListener((s) =>
        {
            if (s.Length == 3)
            {
                StartBtn.SetActive(true);
            }
            else
                StartBtn.SetActive(false);
        });
    }

    private void VideoCallBack(VideoPlayer source)
    {
        luncherModule.SetActive(true);
        Destroy(videoPlayer.gameObject);
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinOrCreateRoom()
    {
        if (SetRoom.text.Length != 3)
            return;
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(SetRoom.text, options, default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("连接上了！");
        waiting.gameObject.SetActive(false);
        EnterGame.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Character");//进入场景
    }
}
