using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Course : MonoBehaviour
{
    #region Image
    public Sprite[] sprites;
    public Image[] images;
    #endregion

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            images[0].sprite = sprites[0];
        }
        if (Input.GetKey(KeyCode.D))
        {
            images[1].sprite = sprites[1];
        }
        if (Input.GetKey(KeyCode.E))
        {
            images[2].sprite = sprites[2];
        }
        if (Input.GetKey(KeyCode.Y))
        {
            images[3].sprite = sprites[3];
        }
    }
}
