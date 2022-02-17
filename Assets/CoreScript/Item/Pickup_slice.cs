using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_slice : MonoBehaviour
{
    private void AddVoiceTime()
    {
        EventManger.instance.RemoveEventListener("pickup", AddVoiceTime);
        PlayVoiceManager.instance.AddVoiceTime(120f);
        Destroy(this.gameObject);
    }

    //提示按“E”
    //E键监听的第一种方式：添加pickup事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        EventManger.instance.AddEventListener("pickup", AddVoiceTime,false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        EventManger.instance.RemoveEventListener("pickup", AddVoiceTime);
    }

}
