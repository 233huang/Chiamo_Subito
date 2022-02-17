using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceTime_Scrollbar : MonoBehaviour
{
    public GameObject voiceTime;
    public GameObject scrollbar;
    private Image image;
    private Scrollbar scr;
    
    void Start()
    {
        image = voiceTime.transform.GetChild(1).GetComponent<Image>();
        scr = scrollbar.GetComponent<Scrollbar>();
        EventManger.instance.AddEventListener<bool>("Transmit", Transmit, false);

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (PlayVoiceManager.instance.Transmit)
        {
            scr.size = PlayVoiceManager.instance.VoiceTime / PlayVoiceManager.instance.MaxVoiceTime;
            PlayVoiceManager.instance.VoiceTime -= Time.deltaTime;

            if (scr.size <= 0||PlayVoiceManager.instance.VoiceTime <=0)
            {
                PlayVoiceManager.instance.Transmit = false;
                PlayVoiceManager.instance.SetVoiceTime(0f);
                image.enabled = false;
                scrollbar.SetActive(false);
            }
        }
    }
    
    void Transmit(bool b)
    {
        if (PlayVoiceManager.instance.VoiceTime > 0)
        {
            image.enabled = b;
            scrollbar.SetActive(b);
        }
    }
}
