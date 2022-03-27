using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAuido_OnAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public string AudioName = "UI通用";
    public void OnAni()
    {
        AudioManager.instance.PlayUIAudio("Music/" + AudioName);
    }
}
