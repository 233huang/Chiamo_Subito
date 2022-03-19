using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

/// <summary>
/// 灯光控制器
/// </summary>
public class LightControl : MonoBehaviour
{
    public string lightname;
    private Light2D light2D;
    // Start is called before the first frame update
    void Awake()
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
        PlayerManager.instance.currentLight.light2d = light2D;
        PlayerManager.instance.currentLight.brl = light2D.intensity;
    }
}
