using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button[] buttons;
    private bool pause = true;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(() => {
            if (videoPlayer.isPlaying)
                videoPlayer.Stop();
            else
                videoPlayer.Play();

        });
        buttons[1].onClick.AddListener(() =>
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        });
        buttons[2].onClick.AddListener(() =>
        {
            if (videoPlayer.isPlaying)
                videoPlayer.time -= 10f;
        });
        buttons[3].onClick.AddListener(() =>
        {
            if (videoPlayer.isPlaying)
                videoPlayer.time += 10f;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
