using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 展示某种物品或事件
/// </summary>
public class OtherView_item : MonoBehaviour
{
    public GameObject show;
    public bool setBGback = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            show.gameObject.SetActive(true);
            if (setBGback)
                PlayerManager.instance.SetLight_Item(0.4f, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
