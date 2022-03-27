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
            if(value == true)
                AudioManager.instance.PlayUIAudio("Music/模块开启");
        }
    }

    private bool modularOne = false;//第一模块
    public bool ModularOne
    {
        get { return modularOne; }
        set
        {
            modularOne = value;
            EventManger.instance.TriggerEventListener<bool>("Box_One", value);
            if (value == true)
                AudioManager.instance.PlayUIAudio("Music/模块开启");
        }
    }

    private bool modularTwo = false;//第二模块
    public bool ModularTwo
    {
        get { return modularTwo; }
        set
        {
            modularTwo = value;
            EventManger.instance.TriggerEventListener<bool>("Box_Two", value);
            if (value == true)
                AudioManager.instance.PlayUIAudio("Music/模块开启");
        }
    }

    private bool modularThree = false;//第三模块
    public bool ModularThree
    {
        get { return modularThree; }
        set
        {
            modularThree = value;
            EventManger.instance.TriggerEventListener<bool>("Box_Three", value);
            if (value == true)
                AudioManager.instance.PlayUIAudio("Music/模块开启");
        }
    }

    private bool modularFour = false;//第四模块
    public bool ModularFour
    {
        get { return modularFour; }
        set
        {
            modularFour = value;
            EventManger.instance.TriggerEventListener<bool>("Box_Four", value);
            if (value == true)
                AudioManager.instance.PlayUIAudio("Music/模块开启");
        }
    }
}
