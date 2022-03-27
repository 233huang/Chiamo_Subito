using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAuido_Button : MonoBehaviour
{
    private Button button;
    public string AudioName = "UI通用";
    void Start()
    {
        button = this.GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlayUIAudio("Music/"+ AudioName);
        });
    }
}
