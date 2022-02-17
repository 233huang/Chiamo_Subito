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
    //private float _maxvoicetime;
    public float MaxVoiceTime { get; set; }

    private float _voicetime;
    public float VoiceTime {
        get { return _voicetime; }
        set {
            _voicetime = value;
        } 
    }

    public void SetTramsmit(bool b)
    {
        if (VoiceTime > 0)
        {
            Transmit = b;
        }
    }

    public void AddVoiceTime(float f)
    {
        VoiceTime += f;
        MaxVoiceTime = VoiceTime;
    }

    public void SetVoiceTime(float f)
    {
        VoiceTime = f;
        MaxVoiceTime = VoiceTime;
    }
}
