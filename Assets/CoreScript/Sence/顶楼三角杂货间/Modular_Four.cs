using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Four : MonoBehaviour
{
    private Button[] buttons = new Button[9];
    
    void Start()
    {
        for(int i = 0; i <= 8; i++)
        {
            buttons[i] = this.transform.GetChild(i).GetComponent<Button>();
            int temp = i;
            buttons[i].onClick.AddListener(() => { 
                buttons[temp].transform.localEulerAngles = new Vector3(0.0f, 0.0f, buttons[temp].transform.localEulerAngles.z - 90);
            });
        }

        SetButtonAble(false);
        EventManger.instance.AddEventListener<bool>("Box_Work", SetButtonAble);
    }

    private void SetButtonAble(bool b)
    {
        if (!Electric_boxManager.instance.ModularThree)
            b = false;
        foreach (Button button in buttons)
        {
            button.interactable = b;
        }
    }

    public void synchro()
    {
        GetComponent<PhotonView>().RPC("otherplayerchoice", RpcTarget.All);
    }

    [PunRPC]
    void otherplayerchoice()
    {
        Debug.Log("开灯啦！");
    }
}
