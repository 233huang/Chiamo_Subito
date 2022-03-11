using System.Collections;
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
        if (Input.GetKey(KeyCode.E))
        {
            Destroy(this.gameObject);
            ItemManager.instance.AddItem("实验室的掉落钥匙");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E.enabled = false;
    }
}
