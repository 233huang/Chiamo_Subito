using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio_OnEnabe : MonoBehaviour
{
    public string AudioName="UI通用";

    private void OnEnable()
    {
        AudioManager.instance.PlayUIAudio("Music/" + AudioName,true);
    }
}
