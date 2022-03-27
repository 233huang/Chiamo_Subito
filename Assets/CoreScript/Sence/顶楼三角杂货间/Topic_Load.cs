using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Topic_Load : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string DragItemName = "NULL";
    public GameObject Keyshow;
    private bool Stay = false;
    private void Start()
    {
        EventManger.instance.AddEventListener<string>("ItemDrag", TryToOpenDoor);
        if (ItemManager.instance.ContainItem("Key") && !SenceDataControl.instance.FrontDoor)
        {
            Keyshow.SetActive(true);
        }
    }
    public void TryToOpenDoor(string ItemName)
    {
        if (DragItemName == "Key"&& Stay == true)
        {
            AudioManager.instance.PlayUIAudio("Music/开门");
            SenceDataControl.instance.FrontDoor = true;
            Keyshow.SetActive(false);
            ItemManager.instance.RemoveItme("Key");
        }
        DragItemName = ItemName;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SenceDataControl.instance.FrontDoor)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayUIAudio("Music/开门");
                SenceLoadManager.instance.LoadSence("格瑞实验室", PlayerManager.instance.PlayerCreatVector["格瑞实验室"][0]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DragItemName == "Key")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Stay = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DragItemName == "Key")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Stay = true;
    }
}
