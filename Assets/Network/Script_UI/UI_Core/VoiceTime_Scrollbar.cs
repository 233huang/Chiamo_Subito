using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceTime_Scrollbar : MonoBehaviour
{
    [SerializeField]
    private GameObject voiceTime;
    [SerializeField]
    private GameObject scrollbar;
    [SerializeField]
    private Image image;

    private Scrollbar scr;

    private bool isDecrease = false;

    private float maxtime = 0;
    private float surplustime = 0;
    // Start is called before the first frame update
    void Start()
    {
        voiceTime = this.gameObject;
        scrollbar = voiceTime.transform.GetChild(0).gameObject;
        image = voiceTime.transform.GetChild(1).GetComponent<Image>();
        scr = scrollbar.GetComponent<Scrollbar>();

        EventManger.instance.AddEventListener("DecreaseTime", DecreaseTime);
        EventManger.instance.AddEventListener<float>("VoiceTimeChance", VoiceTimeChance);
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
        Debug.Log("数值改变了");
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
