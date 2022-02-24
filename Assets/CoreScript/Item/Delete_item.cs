using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_item : MonoBehaviour
{
    public GameObject show;

    private bool del = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            del = true;
        }
    }

    private void Update()
    {
        if (del)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Lerp(this.GetComponent<SpriteRenderer>().color.a, 0f,Time.deltaTime));
            if (this.GetComponent<SpriteRenderer>().color.a <= 0.3)
            {
                show.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
