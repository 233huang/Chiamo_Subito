using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAndLoad : MonoBehaviour
{
    public void LoadNext()
    {
        Photon.Pun.PhotonNetwork.AutomaticallySyncScene = false;

        if (PlayerManager.instance.CharacterID == 0)
        {
            SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][0]);
        }
        if (PlayerManager.instance.CharacterID == 1)
        {
            SenceLoadManager.instance.LoadSence("顶楼三角杂货间", PlayerManager.instance.PlayerCreatVector["顶楼三角杂货间"][0]);
        }
    }
}
