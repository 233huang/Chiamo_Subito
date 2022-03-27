using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_item : MonoBehaviour
{
    private void Start()
    {
        if(itemname == "背包中的废纸团")
            if (SenceDataControl.instance.Paperball)
                Destroy(this.gameObject);
    }


    public string itemname;

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            ItemManager.instance.AddItem(itemname);
            if (itemname == "背包中的废纸团")
                SenceDataControl.instance.Paperball = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

