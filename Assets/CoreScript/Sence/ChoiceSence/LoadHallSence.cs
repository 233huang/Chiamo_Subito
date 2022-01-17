﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadHallSence : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = this.GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(delegate { LoadHall(); });
    }
    private void LoadHall()
    {
        //EventManger.instance.TriggerEventListener<int>("choiceCharacter", PlayerManager.instance.CharacterID);
        Photon.Pun.PhotonNetwork.LoadLevel("Hall");

    }
}
