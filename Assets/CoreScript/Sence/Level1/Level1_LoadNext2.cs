using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level1_LoadNext2 : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public string DragItemName = "NULL";
    private bool Stay = false;
    private void Start()
    {
        EventManger.instance.AddEventListener<string>("ItemDrag", TryToOpenDoor);
    }
    public void TryToOpenDoor(string ItemName)
    {
        if (DragItemName == "华钥匙" && Stay == true)
        {
            SenceDataControl.instance.BedroomDoor = true;
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
        if (DragItemName == "华钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Stay = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("我进来了！");
        if (DragItemName == "华钥匙")
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Stay = true;
    }
}
