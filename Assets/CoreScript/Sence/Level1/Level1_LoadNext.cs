using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_LoadNext : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerManager.instance.CharacterID == 0)
            {
                SenceLoadManager.instance.LoadSence("二楼阳台", PlayerManager.instance.PlayerCreatVector["二楼阳台"][0]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
