using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAuido_Button : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlayUIAudio("Music/UI通用");
        });
    }
}
