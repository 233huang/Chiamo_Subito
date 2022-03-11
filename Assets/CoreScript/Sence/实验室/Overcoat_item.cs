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
    private bool CanE;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        E = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(CanE)
        {
            if (Input.GetKeyDown(KeyCode.E) && !Animationing)
            {
                E.enabled = false;
                Animationing = true;
                index++;
                if (index < 4)
                    animator.Play("摇晃");
                else
                    animator.SetBool("掉落", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        E.enabled = true;
        CanE = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        E.enabled = false;
        CanE = false;
    }

    public void OnFirstAnimationEnd()
    {
        Debug.Log("+1");
        E.enabled = true;
        Animationing = false;
    }
    public void OnSecondAnimationEnd()
    {
        key.SetActive(true);
        animator.SetBool("掉落", false);
        Destroy(this);
    }
}
