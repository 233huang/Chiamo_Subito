using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceManager : Singleton<PlayVoiceManager>
{
    private bool _transmit;//是否可语音交流
    public bool Transmit { 
        get { return _transmit; } 
        set {
            _transmit = value;
            EventManger.instance.TriggerEventListener("Transmit", value);
        } 
    }
    public float MaxVoiceTime { get; set; }

    private float _voicetime;
    public float VoiceTime {
        get { return _voicetime; }
        set {
            _voicetime = value;
        } 
    }

    private int _vocieCount;
    public int VoiceCount{ 
        get { return _vocieCount; } 
        set {

            bool temp = _vocieCount > value ? false : true;
            _vocieCount = value;
            EventManger.instance.TriggerEventListener<bool>("SetVoiceCount",temp );
           
        } }

    public void SetTramsmit(bool b)
    {
        if (VoiceCount > 0)
        {
            Transmit = b;
            AudioManager.instance.PlayUIAudio("Music/UI通用");
        }
        else
        {
            AudioManager.instance.PlayUIAudio("Music/薄片UI零个");
        }
    }

    public void AddVoiceCount(int i)
    {
        VoiceCount+=i;
    }

    public void SetVoiceTime(float f)
    {
        VoiceTime = f;
    }
}
