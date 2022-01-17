﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_slice : MonoBehaviour
{
    private void AddVoiceTime()
    {
        Debug.Log("执行了");
        EventManger.instance.RemoveEventListener("pickup", AddVoiceTime);
        EventManger.instance.TriggerEventListener<float>("AddVoiceTime", 120f);
        Destroy(this.gameObject);
    }

    //提示按“E”
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
