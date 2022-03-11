using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_item : MonoBehaviour
{
    public string itemname;

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            ItemManager.instance.AddItem(itemname);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

