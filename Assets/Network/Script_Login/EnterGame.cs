using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public Animation ani;
    public GameObject smallImage;
    public void AnimPlay()
    {
        ani.enabled = true;
    }

    public void AnimCallBack()
    {
        smallImage.SetActive(true);
        Destroy(this.gameObject);
    }
}
