using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏设置界面
/// </summary>
public class GameInstall : MonoBehaviour
{
    public Scrollbar bgScr;
    public Scrollbar uiScr;
    public Button QuitGame;

    void Start()
    {
        DontDestroyOnLoad(this);
        QuitGame.onClick.AddListener(() => {
            Application.Quit(); });

        bgScr.onValueChanged.AddListener((f) =>
        {
            AudioManager.instance.SetBGAudioVolume(f);
        });

        uiScr.onValueChanged.AddListener((f) =>
        {
            AudioManager.instance.SetUIAduioVolume(f);
        });
    }
}
