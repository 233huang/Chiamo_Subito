using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level1_LoadNext2 : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public string DragItemName = "NULL";
    public GameObject Keyshow;
    private bool Stay = false;
    private void Start()
    {
        EventManger.instance.AddEventListener<string>("ItemDrag", TryToOpenDoor);
        if (ItemManager.instance.ContainItem("华钥匙")&& !SenceDataControl.instance.BedroomDoor)
        {
            Keyshow.SetActive(true);
        }

    }
    public void TryToOpenDoor(string ItemName)
    {
        if (DragItemName == "华钥匙" && Stay == true)
        {
            AudioManager.instance.PlayUIAudio("Music/开门");
            SenceDataControl.instance.BedroomDoor = true;
            Keyshow.SetActive(false);
            ItemManager.instance.RemoveItme("华钥匙");
        }
        DragItemName = ItemName;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SenceDataControl.instance.BedroomDoor)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayUIAudio("Music/开门");
                SenceLoadManager.instance.LoadSence("华森特房间", PlayerManager.instance.PlayerCreatVector["华森特房间"][0]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DragItemName == "华钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Stay = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DragItemName == "华钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Stay = true;
    }
}
