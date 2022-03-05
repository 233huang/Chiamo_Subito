using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcoat_item : MonoBehaviour
{
    public GameObject key;
    private Animator animator;
    private SpriteRenderer E;
    private bool Animationing = false;
    private int index = 0;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        E = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        E.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E)&& !Animationing)
        {
            E.enabled = false;
            Animationing = true;
            index++;
            if (index < 4)
                animator.SetBool("晃动", true);
            else
                animator.SetBool("掉落", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E.enabled = false;
    }

    public void OnFirstAnimationEnd()
    {
        E.enabled = true;
        Animationing = false;
    }
    public void OnSecondAnimationEnd()
    {
        key.SetActive(true);
        Destroy(this);
    }
}
