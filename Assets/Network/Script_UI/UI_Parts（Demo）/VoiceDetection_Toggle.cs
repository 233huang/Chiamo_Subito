using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceDetection_Toggle : MonoBehaviour
{
    private Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = this.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((isOn) => { EventManger.instance.TriggerEventListener<bool>("VoiceDetection_Toggle", isOn); });
    }
}
