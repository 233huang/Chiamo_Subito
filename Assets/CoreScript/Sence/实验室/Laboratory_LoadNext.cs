using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Laboratory_LoadNext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string DragItemName = "NULL";
    private bool Stay = false;
    private void Start()
    {
        EventManger.instance.AddEventListener<string>("ItemDrag", TryToOpenDoor);
    }
    public void TryToOpenDoor(string ItemName)
    {
        if (DragItemName == "实验室的掉落钥匙" && Stay == true)
        {
            SenceDataControl.instance.GeRuiRoom = true;
            ItemManager.instance.RemoveItme("实验室的掉落钥匙");
        }
        DragItemName = ItemName;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SenceDataControl.instance.GeRuiRoom)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SenceLoadManager.instance.LoadSence("格瑞房间", PlayerManager.instance.PlayerCreatVector["格瑞房间"][0]);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DragItemName == "实验室的掉落钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Stay = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DragItemName == "实验室的掉落钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Stay = true;
    }
}
