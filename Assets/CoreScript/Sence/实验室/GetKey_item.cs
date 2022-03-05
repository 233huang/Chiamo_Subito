﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey_item : MonoBehaviour
{
    private SpriteRenderer E;

    private void Start()
    {
        E = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        E.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ItemManager.instance.AddItem("实验室的掉落钥匙");
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E.enabled = false;
    }
}
