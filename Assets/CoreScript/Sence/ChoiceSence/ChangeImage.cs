using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    private Image image;
    private Image oldimage;
    private Image newimage;

    private void Start()
    {
        image = this.GetComponent<Image>();
        oldimage = this.transform.GetChild(0).GetComponent<Image>();
        newimage = this.transform.GetChild(1).GetComponent<Image>();
    }

    public void SetSprite(bool isold)
    {
        if (isold)
        {
            oldimage.enabled = true;
            newimage.enabled = false;
        }
        else
        {
            oldimage.enabled = false;
            newimage.enabled = true;
        }
    }
}
