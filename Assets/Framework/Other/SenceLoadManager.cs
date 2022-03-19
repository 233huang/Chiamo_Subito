using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceLoadManager : Singleton<SenceLoadManager>
{
    public PlayerManager _playerManager;
    PlayerManager playerManager { 
        get { 
            if (_playerManager == null)
                _playerManager = PlayerManager.instance;
            return _playerManager;
        }
    }

    public void LoadSence(string name,Vector3 position)
    {
        playerManager.GetComponent<PhotonView>().RPC("LoadSenceAndDestoryPlayer", RpcTarget.All,
               playerManager.CharacterID);

        playerManager.NextSenceVector = position;
        Photon.Pun.PhotonNetwork.LoadLevel(name);
    }
}
