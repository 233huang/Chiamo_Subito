using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yantai_LoadNext : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][1]);   
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
