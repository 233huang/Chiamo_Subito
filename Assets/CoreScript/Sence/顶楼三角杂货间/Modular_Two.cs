using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Two : MonoBehaviour
{
    private GameObject[] buttons = new GameObject[4];

    public Sprite[] Wire1_Sprite = new Sprite[5];
    public Sprite[] Wire2_Sprite = new Sprite[5];
    public Sprite[] Wire3_Sprite = new Sprite[5];
    public Sprite[] Wire4_Sprite = new Sprite[5];

    public int Wire_selected = -1;//目前选择的电线起始端

    public Dictionary<int, int> WireDic = new Dictionary<int, int>() {
        {1,1},
        {2,3},
        {3,2},
        {4,4}
    };//电线对应关系

    private void Start()
    {
        for(int i=0;i<4;i++)
        {
            buttons[i] = this.transform.GetChild(i).gameObject;
            buttons[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        }
        BtnInit();
    }


    public void ChangeWire(int n)
    {
        WireDic[Wire_selected] = n;
        if (WireDic[1] == 2 && WireDic[2] == 4 && WireDic[3] == 3 && WireDic[4] == 1)
        {
            //缺一个图片替换

            Electric_boxManager.instance.ModularTwo = true;
        }
    }

    private void BtnInit()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(() => {
            if (Wire_selected == -1)
                Wire_selected = 1;
            else
                swapBtn(1);
        });
        buttons[1].GetComponent<Button>().onClick.AddListener(() => {
            if (Wire_selected == -1)
                Wire_selected = 2;
            else
                swapBtn(2);
        });
        buttons[2].GetComponent<Button>().onClick.AddListener(() => {
            if (Wire_selected == -1)
                Wire_selected = 3;
            else
                swapBtn(3);
        });
        buttons[3].GetComponent<Button>().onClick.AddListener(() => {
            if (Wire_selected == -1)
                Wire_selected = 4;
            else
                swapBtn(4);
        });
    }

    private void swapBtn(int b)
    {
        switch (Wire_selected)
        {
            case 1:
                buttons[0].GetComponent<Image>().sprite = Wire1_Sprite[b - 1];
                buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(24+34*(b-1), 110);
                buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-51 + 17 * (b - 1), -25);
                break;
            case 2:
                buttons[1].GetComponent<Image>().sprite = Wire2_Sprite[b - 1];
                break;
            case 3:
                buttons[2].GetComponent<Image>().sprite = Wire3_Sprite[b - 1];
                break;
            case 4:
                buttons[3].GetComponent<Image>().sprite = Wire4_Sprite[b - 1];
                break;
            case -1:
                Debug.LogWarning("出大问题");
                break;
        }
        ChangeWire(b);
        Wire_selected = -1;
    }
}
