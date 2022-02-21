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
        {1,3},
        {2,1},
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
        EventManger.instance.AddEventListener<bool>("Box_One", SetToggleAble);
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
        SetImageSize(s, e);
        ChangeWire();
        Wire_selected = -1;
    }
    public void ChangeWire()
    {
        if (WireDic[1] == 2 && WireDic[2] == 4 && WireDic[3] == 3 && WireDic[4] == 1)
        {
            buttons[0].GetComponent<Image>().sprite = Wire1_Sprite[4];
            buttons[1].GetComponent<Image>().sprite = Wire2_Sprite[4];
            buttons[2].GetComponent<Image>().sprite = Wire3_Sprite[4];
            buttons[3].GetComponent<Image>().sprite = Wire4_Sprite[4];

            Electric_boxManager.instance.ModularTwo = true;
        }
    }

    /// <summary>
    /// 暂且用着
    /// </summary>
    private void SetImageSize(int s,int e)
    {
        Debug.Log("s:" + s + ",e:" + e);
        switch (s)
        {
            case 1:
                switch (e)
                {
                    case 1:
                        buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(31f,146.8f);
                        buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-67.9f,1.2f);
                        break;
                    case 2:
                        buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(71.6f, 146.8f);
                        buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-47.6f, 1.2f);
                        break;
                    case 3:
                        buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(121.8f, 146.8f);
                        buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-22.5f, 1.2f);
                        break;
                    case 4:
                        buttons[0].GetComponent<RectTransform>().sizeDelta = new Vector2(172f, 146.8f);
                        buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(2.6f, 1.2f);
                        break;
                }
                break;
            case 2:
                switch (e)
                {
                    case 1:
                        buttons[1].GetComponent<RectTransform>().sizeDelta = new Vector2(71.6f, 146.8f);
                        buttons[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-47.5f, 1.2f);
                        break;
                    case 2:
                        buttons[1].GetComponent<RectTransform>().sizeDelta = new Vector2(32.7f, 146.8f);
                        buttons[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-21.8f, 1.2f);
                        break;
                    case 3:
                        buttons[1].GetComponent<RectTransform>().sizeDelta = new Vector2(73.9f, 146.8f);
                        buttons[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(6f, 1.2f);
                        break;
                    case 4:
                        buttons[1].GetComponent<RectTransform>().sizeDelta = new Vector2(119.6f, 146.8f);
                        buttons[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(29f, 1.2f);
                        break;
                }
                break;
            case 3:
                switch (e)
                {
                    case 1:
                        buttons[2].GetComponent<RectTransform>().sizeDelta = new Vector2(121.9f, 146.8f);
                        buttons[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-22.5f, 1.2f);
                        break;
                    case 2:
                        buttons[2].GetComponent<RectTransform>().sizeDelta = new Vector2(73f, 146.8f);
                        buttons[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 1.2f);
                        break;
                    case 3:
                        buttons[2].GetComponent<RectTransform>().sizeDelta = new Vector2(31f, 146.8f);
                        buttons[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(27.5f, 1.2f);
                        break;
                    case 4:
                        buttons[2].GetComponent<RectTransform>().sizeDelta = new Vector2(71f, 146.8f);
                        buttons[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(53f, 1.2f);
                        break;
                }
                break;
            case 4:
                switch (e)
                {
                    case 1:
                        buttons[3].GetComponent<RectTransform>().sizeDelta = new Vector2(172f, 146.8f);
                        buttons[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(2.6f, 1.2f);
                        break;
                    case 2:
                        buttons[3].GetComponent<RectTransform>().sizeDelta = new Vector2(119f, 146.8f);
                        buttons[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(25.7f, 1.2f);
                        break;
                    case 3:
                        buttons[3].GetComponent<RectTransform>().sizeDelta = new Vector2(77f, 146.8f);
                        buttons[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(51.3f, 1.2f);
                        break;
                    case 4:
                        buttons[3].GetComponent<RectTransform>().sizeDelta = new Vector2(30f, 146.8f);
                        buttons[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(75f, 1.2f);
                        break;
                }
                break;
        }
    }
}
