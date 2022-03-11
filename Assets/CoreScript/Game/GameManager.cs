using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

/// <summary>
/// 负责角色的生成、角色交互的可视化
/// </summary>
namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public bool CreatePlayer;

        //public Vector3 tran;
        public Vector3 size;

        private PlayerManager playerManager;

        private void Start()
        {
            playerManager = PlayerManager.instance;

            playerManager.GetComponent<PhotonView>().RPC("SetPlayerSences", RpcTarget.All,
                playerManager.CharacterID, SceneManager.GetActiveScene().name);
            
            if (CreatePlayer)
                InstanticPlayer();
        }
        private void Update()
        {
            if (playerManager == null)
                return;
            if (SceneManager.GetActiveScene().name == playerManager.PlayerScenes[playerManager.CharacterID == 0 ? 1 : 0])
            {
                Camera.main.cullingMask = -1;
            }
            else
            {
                SetCameraMask();
            }
        }

        private void InstanticPlayer()
        {
            if (playerManager.CharacterID == 0)
            {
                //GameObject player = PhotonNetwork.Instantiate("Player/LiAng", tran, Quaternion.identity, 0);
                GameObject player = PhotonNetwork.Instantiate("Player/LiAng", 
                    playerManager.NextSenceVector,
                    Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
            if (playerManager.CharacterID == 1)
            {
                //GameObject player = PhotonNetwork.Instantiate("Player/LiLiAn", tran, Quaternion.identity, 0);
                GameObject player = PhotonNetwork.Instantiate("Player/LiLiAn",
                    playerManager.NextSenceVector,
                    Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
            SetCameraMask();
        }

        private void SetCameraMask()
        {
            if (playerManager.CharacterID == 0)
            {
                Camera.main.cullingMask &= ~(1 << 9);
            }
            if (playerManager.CharacterID == 1)
            {
                Camera.main.cullingMask &= ~(1 << 8);
            }
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

    }
}
