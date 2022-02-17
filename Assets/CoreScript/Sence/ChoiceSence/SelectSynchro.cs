using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SelectSynchro :MonoBehaviourPunCallbacks
{
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PlayerManager.instance.CharacterID == 0 || PlayerManager.instance.CharacterID == 1)
        {
            PlayerManager.instance.gameObject.GetComponent<PhotonView>().RPC("OtherPlayerChoice", RpcTarget.All, PlayerManager.instance.CharacterID);
        }
    }

}
