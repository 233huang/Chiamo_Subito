using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// 游戏全局管理类
/// </summary>
namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public bool CreatePlayer;

        public Vector3 tran;
        public Vector3 size;
        private void Awake()
        {
            if(CreatePlayer)
                InstanticPlayer();
        }

        private void InstanticPlayer()
        {
            if (PlayerManager.instance.CharacterID == 0)
            {
                GameObject player = PhotonNetwork.Instantiate("Player/LiAng",tran, Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
            if (PlayerManager.instance.CharacterID == 1)
            {
                GameObject player = PhotonNetwork.Instantiate("Player/LiLiAn", tran, Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
    }
}
