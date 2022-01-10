using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SelectSynchro :MonoBehaviourPunCallbacks
{
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        EventManger.instance.TriggerEventListener<int>("choiceCharacter", PlayerManager.instance.CharacterID);
    }
}
