using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// 登入,连接网络
/// </summary>
namespace Com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        public bool AutoConnect = false;
        string GameVersion = "1";
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        bool isConnecting;

        private void Awake()
        {
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            if (this.AutoConnect)
            {
                this.Connect();
            }
        }

        public void Connect()
        {
            // 检查是否已连接，如果已连接，则加入，否则启动与服务器的连接。
            if (PhotonNetwork.IsConnected)
            {
                // 需要在这一点上尝试加入一个随机房间。如果失败，我们将在OnJoinRandomFailed（）中收到通知。
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // 必须首先连接到PUN在线服务器。
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GameVersion;
            }
        }

        #region MonoBehaviourPunCallbacks Callbacks

        /// <summary>
        /// 连接后的回调函数
        /// </summary>
        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
                Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            }
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                PhotonNetwork.LoadLevel("Demo");//进入场景
            }
        }
        public override void OnJoinedLobby()
        {
            Debug.Log("OnJoinedLobby(). This client is now connected to Relay in region [" + PhotonNetwork.CloudRegion + "]. This script now calls: PhotonNetwork.JoinRandomRoom();");
            //PhotonNetwork.JoinRandomRoom();
        }
        #endregion

        
    }
}
