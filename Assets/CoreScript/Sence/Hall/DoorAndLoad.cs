using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAndLoad : MonoBehaviour
{
    bool enter = false;
    private void Update()
    {
        if (enter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Photon.Pun.PhotonNetwork.AutomaticallySyncScene = false;

                if (PlayerManager.instance.CharacterID == 0)
                {
                    //SceneManager.LoadScene("Level1");
                    SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][0]);
                }
                if (PlayerManager.instance.CharacterID == 1)
                {
                    //SceneManager.LoadScene("顶楼三角杂货间");
                    SenceLoadManager.instance.LoadSence("顶楼三角杂货间", PlayerManager.instance.PlayerCreatVector["顶楼三角杂货间"][0]);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        enter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enter = false;
    }
}
