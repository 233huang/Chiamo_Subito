using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Control : Singleton<Light_Control>
{
    public Dictionary<string,bool> LightDic;

    void Open(string name)
    {
        LightDic[name] = true;
    }

    void Close(string name)
    {
        LightDic[name] = false;
    }

}
