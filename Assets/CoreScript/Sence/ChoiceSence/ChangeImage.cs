using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    private SpriteRenderer image;
    public Sprite sprite;
    private Sprite oldsprite;
    private GameObject child;

    private void Awake()
    {
        image = this.gameObject.GetComponent<SpriteRenderer>();
        oldsprite = image.sprite;
        child = this.transform.GetChild(0).gameObject;
    }
    public void chance(bool ischange)
    {
         image.sprite = ischange? sprite:oldsprite;
         child.GetComponent<SpriteRenderer>().enabled = ischange;
    }
}
