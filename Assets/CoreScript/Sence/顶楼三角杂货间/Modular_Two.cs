using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Two : MonoBehaviour
{
    #region 按钮及图片的引用定义
    private GameObject[] buttons = new GameObject[4];

    public Sprite[] Wire1_Sprite = new Sprite[5];
    public Sprite[] Wire2_Sprite = new Sprite[5];
    public Sprite[] Wire3_Sprite = new Sprite[5];
    public Sprite[] Wire4_Sprite = new Sprite[5];
    #endregion

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
        EventManger.instance.AddEventListener<bool>("Box_Work", SetToggleAble);
        SetToggleAble(false);
    }

    private void SetToggleAble(bool b)
    {
        if (!Electric_boxManager.instance.ModularOne)
            b = false;
        foreach(GameObject button in buttons)
        {
            button.GetComponent<Button>().interactable = b;
        }
    }
    public void ChangeWire()
    {
        if (WireDic[1] == 2 && WireDic[2] == 4 && WireDic[3] == 3 && WireDic[4] == 1)
        {
            //缺一个图片替换

            Electric_boxManager.instance.ModularTwo = true;
        }
    }

    /// <summary>
    /// 按钮监听初始化
    /// </summary>
    private void BtnInit()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(() => {
            BtnListener(1);
        });
        buttons[1].GetComponent<Button>().onClick.AddListener(() => {
            BtnListener(2);
        });
        buttons[2].GetComponent<Button>().onClick.AddListener(() => {
            BtnListener(3);
        });
        buttons[3].GetComponent<Button>().onClick.AddListener(() => {
            BtnListener(4);
        });
    }

    private void BtnListener(int i)
    {
        if (Wire_selected == -1)
            Wire_selected = i;
        else
        {
            int temp = WireDic[Wire_selected];
            swapBtn(Wire_selected, WireDic[i]);
            swapBtn(i, temp);
        }
    }

    /// <summary>
    /// 交互按钮的位置
    /// </summary>
    /// <param name="s">电线起始位置</param>
    /// <param name="e">电线末端位置</param>
    private void swapBtn(int s,int e)
    {
        switch (s)
        {
            case 1:
                buttons[0].GetComponent<Image>().sprite = Wire1_Sprite[e - 1];
                buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(24+34*(e-1), 110);
                buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-51 + 17 * (e - 1), -25);
                WireDic[1] = e;
                break;
            case 2:
                buttons[1].GetComponent<Image>().sprite = Wire2_Sprite[e - 1];
                WireDic[2] = e;
                break;
            case 3:
                buttons[2].GetComponent<Image>().sprite = Wire3_Sprite[e - 1];
                WireDic[3] = e;
                break;
            case 4:
                buttons[3].GetComponent<Image>().sprite = Wire4_Sprite[e - 1];
                WireDic[4] = e;
                break;
            case -1:
                Debug.LogWarning("出大问题");
                break;
        }
        ChangeWire();
        Wire_selected = -1;
    }
}
