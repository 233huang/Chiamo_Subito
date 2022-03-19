using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureAni_item : MonoBehaviour
{
    public GameObject g;
    private Animator animator;
    public 

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
                transform.GetChild(0).gameObject.SetActive(false);
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
