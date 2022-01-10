using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射线检测类
/// </summary>
public class ChinarRayCast : MonoBehaviour
{
    private GameObject endObject = null;
    private bool isChoice=false;
    private int otherPlayerChoice = -1;
    
    public GameObject liang;
    public GameObject lilian;


    private void Start()
    {
        EventManger.instance.AddEventListener<int>("choiceCharacter", synchro);
    }

    void Update()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray, Vector2.zero);
        if (hit.collider != null)
        {
            if(hit.collider.name == "LiAng"&& otherPlayerChoice!=0)//且还没有其它玩家选择的时候
            {
                if (!isChoice)//是否已经处于选中状态
                {
                    if (otherPlayerChoice == -1)
                        reduction();
                    endObject = hit.collider.gameObject;
                    endObject.GetComponent<ChangeImage>().chance(true);
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (otherPlayerChoice == -1)
                        reduction();
                    endObject = hit.collider.gameObject;
                    endObject.GetComponent<ChangeImage>().chance(true);
                    PlayerManager.instance.CharacterID = 0;
                    isChoice = true;
                    synchro(0);
                }
            }
            else if(hit.collider.name == "LiLiAn"&& otherPlayerChoice!=1)
            {
                if (!isChoice)
                {
                    if (otherPlayerChoice == -1)
                        reduction();
                    endObject = hit.collider.gameObject;
                    endObject.GetComponent<ChangeImage>().chance(true);
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (otherPlayerChoice == -1)
                        reduction();
                    endObject = hit.collider.gameObject;
                    endObject.GetComponent<ChangeImage>().chance(true);
                    PlayerManager.instance.CharacterID = 1;
                    isChoice = true;
                    synchro(1);
                }
            }
        }
        else
        {
            if(!isChoice)
                reduction();
        }
    }
    void reduction()
    {
        if (endObject != null)
            endObject.GetComponent<ChangeImage>().chance(false);
    }

    public void synchro(int id)
    {
        GetComponent<PhotonView>().RPC("otherplayerchoice", RpcTarget.All, id);
    }

    [PunRPC]
    void otherplayerchoice(int id)
    {
        Debug.Log("有其它玩家选择了角色");
        otherPlayerChoice = id;
        if(id == 0)
        {
            liang.GetComponent<ChangeImage>().chance(true);
        }
        if (id == 1)
        {
            lilian.GetComponent<ChangeImage>().chance(true);
        }
    }
}