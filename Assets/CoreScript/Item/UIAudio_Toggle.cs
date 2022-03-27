using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudio_Toggle : MonoBehaviour
{
    private Toggle toggle;
    public string AudioName = "UI通用";
    void Start()
    {
        toggle = this.GetComponent<Toggle>();

        toggle.onValueChanged.AddListener((v) =>
        {
            AudioManager.instance.PlayUIAudio("Music/" + AudioName);
        });
    }
}
