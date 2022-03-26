using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource bgAudio;
    public AudioSource uiAudio;

    private Dictionary<string, string> audioPathDic = new Dictionary<string, string>();

    private void Start()
    {
        InitSvc();
    }

    public void InitSvc()
    {
        instance = this;
        DontDestroyOnLoad(this);
        audioPathDic.Add("通用", "Music/（主bgm-其余场景都用这个）Big Eyes");
        audioPathDic.Add("二楼阳台", "Music/（二楼阳台）Connecting Rainbows");
        audioPathDic.Add("华森特房间", "Music/（华森特房间）Painful Disorientation");
        audioPathDic.Add("浴室", "Music/（浴室）Kalimba Relaxation Music");
        audioPathDic.Add("结束", "Music/（结束）Painting Room");
    }

    public void PlayBGMusic(string name, bool isLoop)
    {
        AudioClip audio = LoadAudio(name, true);
        if (bgAudio.clip == null || bgAudio.clip.name != audio.name)
        {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    public void PlayBGMusicWithSenceName(string name)
    {
        string path;
        if(audioPathDic.TryGetValue(name,out path ))
            PlayBGMusic(path, true);
        else
            PlayBGMusic(audioPathDic["通用"], true);
    }

    public void PlayUIAudio(string name)
    {
        AudioClip audio = LoadAudio(name, true);
        uiAudio.clip = audio;
        uiAudio.Play();
    }

    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string path, bool cache = false)
    {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au))
        {
            au = Resources.Load<AudioClip>(path);
            if (cache)
            {
                adDic.Add(path, au);
            }
        }
        return au;
    }
}
