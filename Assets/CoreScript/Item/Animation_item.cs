﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 会触发动画的物体
/// </summary>
public class Animation_item : MonoBehaviour
{
    public GameObject g;
    private Animator animator;

    bool enter = false;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (enter)
        {
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetBool("run", true);
                Destroy(transform.GetChild(0).gameObject);
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        enter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enter = false;
    }

    private void Instantic()
    {
        g.SetActive(true);
    }
}
