using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Topic_Load : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerManager.instance.CharacterID == 1)
            {
                if (ItemManager.instance.ItemDic.ContainsKey("Key"))
                {
                     SenceLoadManager.instance.LoadSence("格瑞实验室", PlayerManager.instance.PlayerCreatVector["格瑞实验室"][0]);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
