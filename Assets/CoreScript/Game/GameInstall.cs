using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
