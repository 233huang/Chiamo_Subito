using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SelectManager : MonoBehaviour
{
    public CharacterSelection LiAng;
    public CharacterSelection LiLiAn;
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        LiAng.OnMouseUp += PointerUP;
        LiLiAn.OnMouseUp += PointerUP;
    }

    private void PointerUP(int roleID)
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerManager.alreadyChocieCharacter[roleID] == false)
        {
            playerManager.CharacterID = roleID;
            playerManager.gameObject.GetComponent<PhotonView>().RPC("OtherPlayerChoice", RpcTarget.All, roleID);
        }
    }

    private void Update()
    {
        if (playerManager.alreadyChocieCharacter[0])
        {
            LiAng.roleSelected = true;
            LiAng.SetSelected();
        }
        if (playerManager.alreadyChocieCharacter[1])
        {
            LiLiAn.roleSelected = true;
            LiLiAn.SetSelected();
        }
    }
}
