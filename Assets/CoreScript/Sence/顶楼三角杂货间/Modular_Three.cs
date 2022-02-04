using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modular_Three : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggles = new Toggle[6];


    private int[] btnsort = new int[] { 2,1,6,3,5,4};//按钮的标准答案

    private Queue<int> btn = new Queue<int>();//保存操作的按钮顺序

    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            toggles[i] = this.gameObject.transform.GetChild(i).GetComponent<Toggle>();
            int temp = i;
            toggles[i].onValueChanged.AddListener((b) => { 
                if (b)
                {
                    Debug.Log(temp + 1);
                    AddBtn(temp+1);
                }
            });
        }
    }

    public void AddBtn(int n)
    {
        if (btn.Contains(n))
            return;
        btn.Enqueue(n);

        if (btn.Count == 6)
        {
            bool temp = true;
            for (int i = 0; i < 6; i++)
            {
                if (btn.Dequeue() != btnsort[i])
                {
                    temp = false;
                }
                    
                toggles[i].isOn = false;
            }
            if (temp)
            {
                Electric_boxManager.instance.ModularThree = true;
            }
        }
    }
}
