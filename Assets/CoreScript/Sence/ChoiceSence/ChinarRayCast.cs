using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射线检测类
/// </summary>
public class ChinarRayCast : MonoBehaviour
{
    private bool isChoice = false;

    public ChangeImage liang;
    public ChangeImage lilian;

    private void Start()
    {
        EventManger.instance.AddEventListener<int>("OtherPlayerChoice", OtherPlayerChoice);//有玩家选择人物后就执行该事件
        OtherPlayerChoice(PlayerManager.instance.OtherCharacterID);
    }

    void Update()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.name == "LiAng")
            {
                liang.chance(true);
                if (PlayerManager.instance.OtherCharacterID != 1 && PlayerManager.instance.CharacterID != 1)
                    lilian.chance(false);
                if (Input.GetKeyDown(KeyCode.Return) && PlayerManager.instance.OtherCharacterID != 0)
                {
                    if (!isChoice)
                    {
                        PlayerManager.instance.CharacterID = 0;
                        isChoice = true;
                        if (PlayerManager.instance.OtherCharacterID != -1)
                            LoadNextScence();
                        PlayerManager.instance.gameObject.GetComponent<PhotonView>().RPC("OtherPlayerChoice", RpcTarget.All, 0);
                    }
                }
            }
            if (hit.collider.name == "LiLiAn")
            {
                lilian.chance(true);
                if (PlayerManager.instance.OtherCharacterID != 0 && PlayerManager.instance.CharacterID != 0)
                    liang.chance(false);
                if (Input.GetKeyDown(KeyCode.Return) && PlayerManager.instance.OtherCharacterID != 1)
                {
                    if (!isChoice)
                    {
                        PlayerManager.instance.CharacterID = 1;
                        isChoice = true;
                        if (PlayerManager.instance.OtherCharacterID != -1)
                            LoadNextScence();
                        PlayerManager.instance.gameObject.GetComponent<PhotonView>().RPC("OtherPlayerChoice", RpcTarget.All, 1);
                    }
                }
            }
        }
        else
        {
            if (PlayerManager.instance.OtherCharacterID != 1 && PlayerManager.instance.CharacterID != 1)
                lilian.chance(false);
            if (PlayerManager.instance.OtherCharacterID != 0 && PlayerManager.instance.CharacterID != 0)
                liang.chance(false);
        }
    }

    void OtherPlayerChoice(int id)
    {
        if (id == 0)
        {
            liang.GetComponent<ChangeImage>().chance(true);
        }
        if (id == 1)
        {
            lilian.GetComponent<ChangeImage>().chance(true);
        }
    }

    void LoadNextScence()
    {
        PhotonNetwork.LoadLevel("Hall");
    }
}