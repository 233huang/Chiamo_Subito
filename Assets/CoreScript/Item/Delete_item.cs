using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_item : MonoBehaviour
{
    public GameObject show;
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine("Show");
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(2f);
        show.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
