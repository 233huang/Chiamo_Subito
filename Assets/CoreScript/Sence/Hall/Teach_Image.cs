using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teach_Image : MonoBehaviour
{
    private SpriteRenderer image;
    public Sprite sprite;
    private Sprite oldsprite;

    private void Awake()
    {
        image = this.gameObject.GetComponent<SpriteRenderer>();
        oldsprite = image.sprite;
    }
    public void chance(bool ischange)
    {
        image.sprite = ischange ? sprite : oldsprite;
    }
}
