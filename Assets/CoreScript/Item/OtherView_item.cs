using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherView_item : MonoBehaviour
{
    bool enter=false;
    private void Update()
    {
        if (enter)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("测试1");
                EventManger.instance.TriggerEventListener<Transform>("OtherView", this.transform);
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
}
