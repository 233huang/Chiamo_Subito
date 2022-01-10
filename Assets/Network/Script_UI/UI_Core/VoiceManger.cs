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
        Voice_Toggle();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Voice_Toggle()
    {
        EventManger.instance.AddEventListener<bool>("Transmit_Toggle", Transmit);
        EventManger.instance.AddEventListener<bool>("VoiceDetection_Toggle", VoiceDetection);
        EventManger.instance.AddEventListener<float>("AddVoiceTime", AddVoiceTime);
    }

    private void Transmit(bool isOn)
    {
        this.recorder.TransmitEnabled = isOn;//控制传输功能开关
        PlayVoiceManager.instance.Transmit = true;
    }
    private void VoiceDetection(bool isOn)
    {
        this.recorder.VoiceDetection = isOn;//启用或禁用语音检测功能
        PlayVoiceManager.instance.Transmit = false;
    }

    private void AddVoiceTime(float f)
    {
        if (!PlayVoiceManager.instance.Transmit)
            Transmit(true);
        PlayVoiceManager.instance.VoiceTime += f;
        Debug.Log("时间增加了：" + f);
    }
}
