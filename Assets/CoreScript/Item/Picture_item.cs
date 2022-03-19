using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture_item : MonoBehaviour
{
    public GameObject g;
    public Sprite result;

    private Animator animator;
    bool enter = false;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        if (SenceDataControl.instance.Picture)
        {
            Debug.Log("Picture!!");
            g.SetActive(true);
            animator.enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = result;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (enter)
        {
            if (Input.GetKey(KeyCode.E)&& !SenceDataControl.instance.Picture)
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
        SenceDataControl.instance.Picture = true;
    }
}
