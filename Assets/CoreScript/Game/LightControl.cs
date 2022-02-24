using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightControl : MonoBehaviour
{
    public string lightname;
    private Light2D light2D;
    // Start is called before the first frame update
    void Start()
    {
        light2D = this.GetComponent<Light2D>();
        EventManger.instance.AddEventListener<string,float>("Light",SetLight,false);
        light2D.intensity = PlayerManager.instance.lightDic[lightname];
    }

    void SetLight(string s,float f)
    {
        if (s != lightname)
            return;
        light2D.intensity = f;
    }
}
