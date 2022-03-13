using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_slice : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            PlayVoiceManager.instance.AddVoiceCount(1);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
