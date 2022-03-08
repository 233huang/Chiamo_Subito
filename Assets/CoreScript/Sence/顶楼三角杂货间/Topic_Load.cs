using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Topic_Load : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string DragItemName = "NULL";
    private bool Stay = false;
    private void Start()
    {
        EventManger.instance.AddEventListener<string>("ItemDrag", TryToOpenDoor);
    }
    public void TryToOpenDoor(string ItemName)
    {
        if (DragItemName == "Key"&& Stay == true)
        {
            SenceDataControl.instance.FrontDoor = true;
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
        Stay = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Stay = true;
    }
}
