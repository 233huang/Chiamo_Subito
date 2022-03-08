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
                CheckResult();
            });
        }

        SetButtonAble(false);
        EventManger.instance.AddEventListener<bool>("Box_Three", SetButtonAble);
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

    private void CheckResult()
    {
        bool temp = true;
        for(int i = 0; i <= 4; i++)
        {
            if ((int)buttons[i].transform.localEulerAngles.z != 90)
                temp = false;
        }
        if(temp)
        {
            Debug.Log("x");
            Electric_boxManager.instance.ModularFour = true;
            //PlayerManager.instance.GetComponent<PhotonView>().RPC("SetLight", RpcTarget.All, "level1", 1f);
            //PlayerManager.instance.GetComponent<PhotonView>().RPC("SetLight", RpcTarget.All, "杂货间", 1f);
        }            
    }


    public void synchro()
    {
        GetComponent<PhotonView>().RPC("otherplayerchoice", RpcTarget.All);
    }
}
