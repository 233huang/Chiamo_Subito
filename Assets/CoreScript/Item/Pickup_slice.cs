using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_slice : MonoBehaviour
{
    public int id = -1;

    private void Start()
    {
        if (id == -1)
            return;
        if (SenceDataControl.instance.BoPian[id])
            Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            PlayVoiceManager.instance.AddVoiceCount(1);
            EventManger.instance.TriggerEventListener("PickUp");
            SenceDataControl.instance.BoPian[id] = true;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
