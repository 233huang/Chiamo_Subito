using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Two : MonoBehaviour
{
    private Button[] button = new Button[4];


    public int Wire_selected;//目前选择的电线起始端

    public Dictionary<int, int> WireDic = new Dictionary<int, int>() {
        {1,1},
        {2,3},
        {3,2},
        {4,4}
    };//电线对应关系

    public void ChangeWire(int n)
    {
        WireDic[Wire_selected] = n;
        if (WireDic[1] == 2 && WireDic[2] == 4 && WireDic[3] == 3 && WireDic[4] == 1)
        {
            EventManger.instance.TriggerEventListener("Wire_Complete");
        }
    }
}
