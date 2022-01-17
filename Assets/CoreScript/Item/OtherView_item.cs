using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 展示某种物品事件、或切换第一视角
/// </summary>
public class OtherView_item : MonoBehaviour
{
    public GameObject show;

    bool enter=false;
    private void Update()
    {
        if (enter)
        {
            if (Input.GetKey(KeyCode.E))
            {
                EventManger.instance.TriggerEventListener<GameObject>("OtherView", this.gameObject);
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
