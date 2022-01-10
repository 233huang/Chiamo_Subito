using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class DemoVoice : MonoBehaviour
{
    private PhotonVoiceView photonVoiceView;
    [SerializeField]
    private SpriteRenderer recorderSprite;
    private void Awake()
    {
        this.photonVoiceView = this.GetComponentInParent<PhotonVoiceView>();
    }

    void Update()
    {
        this.recorderSprite.enabled = this.photonVoiceView.IsRecording;
    }
}
