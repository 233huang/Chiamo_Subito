using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric_boxManager : Singleton<Electric_boxManager>
{
    private bool work = false;//配电箱是否处于工作状态
    public bool Work { 
        get { return work; }
        set {
            EventManger.instance.TriggerEventListener<bool>("Box_Work", value);
            work = value; 
        }
    }

    private bool modularOne = false;//第一模块
    public bool ModularOne
    {
        get { return modularOne; }
        set
        {
            modularOne = value;
        }
    }


    private Stack<int> btnsort = new Stack<int>(new int[] { 2,1,6,3,5,4});//按钮的标准答案

    private Stack<int> btn = new Stack<int>();//保存操作的按钮顺序


    public void AddBtn(int n)
    {
        btn.Push(n);
        if(btn.Count == 6)
        {
            if(btn == btnsort)
                EventManger.instance.TriggerEventListener("Btn_Complete");
            else
            {
                while (btn.Count != 0)
                {
                    btn.Pop();
                }
                EventManger.instance.TriggerEventListener("Btn_Fail");
            }
        }
    }


}
