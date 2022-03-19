using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OpeningVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject Game;
    public GameObject heidong;

    void Start()
    {
        int temp = PlayerManager.instance.CharacterID;
        videoPlayer = this.transform.GetChild(temp).GetComponent<VideoPlayer>();
        Destroy(this.transform.GetChild(temp == 0 ? 1:0).gameObject) ;

        videoPlayer.loopPointReached += ((VideoPlayer source) => {
            Game.SetActive(true);
            heidong.SetActive(true);
            Destroy(this.gameObject);
        });
    }
}
