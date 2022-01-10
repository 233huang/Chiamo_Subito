using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceManager : Singleton<PlayVoiceManager>
{
    public bool Transmit;

    private float voicetime;
    public float VoiceTime {
        get { return voicetime; }
        set {
            voicetime = value;
            EventManger.instance.TriggerEventListener("VoiceTimeChance",value);
        } 
    }
}
