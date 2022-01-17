using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceTime_Scrollbar : MonoBehaviour
{
    private GameObject voiceTime;
    private GameObject scrollbar;
    private Image image;
    private Scrollbar scr;

    private bool isDecrease = false;//是否处于语音状态

    private float maxtime = 0;//最大时间
    private float surplustime = 0;//剩余时间
    
    void Start()
    {
        voiceTime = this.gameObject;
        scrollbar = voiceTime.transform.GetChild(0).gameObject;
        image = voiceTime.transform.GetChild(1).GetComponent<Image>();
        scr = scrollbar.GetComponent<Scrollbar>();

        EventManger.instance.AddEventListener("DecreaseTime", DecreaseTime);//事件：开启/关闭语音
        EventManger.instance.AddEventListener<float>("VoiceTimeChance", VoiceTimeChance);//事件：语音最大时长改变
    }

    void Update()
    {
        if (isDecrease)
        {
            scr.size = surplustime / maxtime;
            surplustime -= Time.deltaTime;
            if (scr.size <= 0)
            {
                isDecrease = false;
                maxtime = 0;
                surplustime = 0;
                image.enabled = false;
                scrollbar.SetActive(false);
            }
        }
    }
    
    void VoiceTimeChance(float f)
    {
        maxtime = f;
        surplustime += f;
        image.enabled = true;
        scrollbar.SetActive(true);
    }

    void DecreaseTime()
    {
        if (PlayVoiceManager.instance.Transmit)
        {
            isDecrease = !isDecrease;
        }
    }
}
