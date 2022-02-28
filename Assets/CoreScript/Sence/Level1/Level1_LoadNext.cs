using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_LoadNext : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            if (PlayerManager.instance.CharacterID == 0)
            {
                SceneManager.LoadScene("二楼阳台");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
