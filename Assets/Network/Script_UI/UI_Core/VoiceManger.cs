using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class VoiceManger : MonoBehaviour
{
    [SerializeField]
    private Recorder recorder;

    private void Awake()
    {
        this.recorder = this.GetComponent<Recorder>();
        VoiceInit();
        DontDestroyOnLoad(this.gameObject);
    }

    private void VoiceInit()
    {
        EventManger.instance.AddEventListener<bool>("Transmit", Transmit,false);
        EventManger.instance.AddEventListener<bool>("VoiceDetection", VoiceDetection);
    }

    private void Transmit(bool isOn)
    {
        this.recorder.TransmitEnabled = isOn;//控制传输功能开关
    }
    private void VoiceDetection(bool isOn)
    {
        this.recorder.VoiceDetection = isOn;//启用或禁用语音检测功能
    }
}
