using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_LoadNext3 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SenceDataControl.instance.BathroomDoor)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SenceLoadManager.instance.LoadSence("二楼浴室", PlayerManager.instance.PlayerCreatVector["二楼浴室"][0]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
