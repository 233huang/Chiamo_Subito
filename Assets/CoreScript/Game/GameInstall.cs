using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏设置界面
/// </summary>
public class GameInstall : MonoBehaviour
{
    public Scrollbar[] scrollbars;
    public Button QuitGame;

    void Start()
    {
        DontDestroyOnLoad(this);
        QuitGame.onClick.AddListener(() => { Application.Quit(); });
        //scrollbars[0].onValueChanged.AddListener();
    }
}
