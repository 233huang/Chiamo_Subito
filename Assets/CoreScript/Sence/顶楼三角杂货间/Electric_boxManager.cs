using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric_boxManager : Singleton<Electric_boxManager>
{
    private bool work = false;//配电箱是否处于工作状态
    public bool Work { 
        get { return work; }
        set {
            work = value;
            EventManger.instance.TriggerEventListener<bool>("Box_Work", work);
        }
    }

    private bool modularOne = false;//第一模块
    public bool ModularOne
    {
        get { return modularOne; }
        set
        {
            EventManger.instance.TriggerEventListener<bool>("Box_One", value);
            modularOne = value;
        }
    }

    private bool modularTwo = false;//第二模块
    public bool ModularTwo
    {
        get { return modularTwo; }
        set
        {
            EventManger.instance.TriggerEventListener<bool>("Box_Two", value);
            modularTwo = value;
        }
    }

    private bool modularThree = false;//第三模块
    public bool ModularThree
    {
        get { return modularThree; }
        set
        {
            modularThree = value;
        }
    }
}
