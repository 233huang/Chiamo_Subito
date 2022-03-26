using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 语音面板控制
/// </summary>
public class VoiceTime_Scrollbar : MonoBehaviour
{
    public GameObject voiceTime;
    public GameObject scrollbar;
    public Text text;
    public Sprite[] Yon;
    public Animator animator;

    private Image imageY;
    private Scrollbar scr;
    
    void Start()
    {
        imageY = voiceTime.transform.GetChild(1).GetComponent<Image>();
        scr = scrollbar.GetComponent<Scrollbar>();
        EventManger.instance.AddEventListener<bool>("Transmit", Transmit, false);
        EventManger.instance.AddEventListener<bool>("SetVoiceCount", SetVoiceCount);

        PlayVoiceManager.instance.VoiceTime = 120f;
        PlayVoiceManager.instance.MaxVoiceTime = 120f;

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
                PlayVoiceManager.instance.VoiceCount--;
                scr.size = 1;
                PlayVoiceManager.instance.VoiceTime = 120f;
                if (PlayVoiceManager.instance.VoiceCount == 0)
                {
                    PlayVoiceManager.instance.Transmit = false;
                    PlayVoiceManager.instance.SetVoiceTime(0f);
                    imageY.enabled = false;
                    scrollbar.SetActive(false);
                }
            }
        }
    }
    
    void Transmit(bool b)
    {
        if (PlayVoiceManager.instance.VoiceCount > 0)
        {
            if (!voiceTime.activeSelf)
                voiceTime.SetActive(true);
            if (b)
            {
                animator.enabled = true;
                imageY.sprite = Yon[1];
                
            }else
            {
                animator.enabled = false;
                imageY.sprite = Yon[0];
            }
        }
    }

    void SetVoiceCount(bool b)
    {
        text.text = PlayVoiceManager.instance.VoiceCount.ToString();
        if (!voiceTime.activeSelf)
            voiceTime.SetActive(true);
    }
}
