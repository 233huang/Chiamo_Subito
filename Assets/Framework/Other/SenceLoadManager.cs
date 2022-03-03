using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceLoadManager : Singleton<SenceLoadManager>
{
    public void LoadSence(string name,Vector3 position)
    {
        PlayerManager.instance.NextSenceVector = position;
        Photon.Pun.PhotonNetwork.LoadLevel(name);
    }
}
