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
        private void Start()
        {
            //EventManger.instance.AddEventListener("PhotonInstanticPlayer", PhotonInstanticPlayer);

            PlayerManager.instance.GetComponent<PhotonView>().RPC("SetPlayerSences", RpcTarget.All,
                PlayerManager.instance.CharacterID, SceneManager.GetActiveScene().name);
            
            if (CreatePlayer)
                InstanticPlayer();
        }
        private void Update()
        {
            if (SceneManager.GetActiveScene().name == PlayerManager.instance.PlayerScenes[PlayerManager.instance.CharacterID == 0 ? 1 : 0])
            {
                Camera.main.cullingMask = -1;
            }
            else
            {
                SetCameraMask();
            }
            /*if (Input.GetKey(KeyCode.X))
            {
                Camera.main.cullingMask = -1;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                SetCameraMask();
            }*/
        }

        private void InstanticPlayer()
        {
            if (PlayerManager.instance.CharacterID == 0)
            {
                GameObject player = PhotonNetwork.Instantiate("Player/LiAng", tran, Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
            if (PlayerManager.instance.CharacterID == 1)
            {
                GameObject player = PhotonNetwork.Instantiate("Player/LiLiAn", tran, Quaternion.identity, 0);
                player.transform.localScale = size;
                player.transform.SetParent(GameObject.Find("Game").transform);
            }
            SetCameraMask();
        }

        private void SetCameraMask()
        {
            if (PlayerManager.instance.CharacterID == 0)
            {
                Camera.main.cullingMask &= ~(1 << 9);
            }
            if (PlayerManager.instance.CharacterID == 1)
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
