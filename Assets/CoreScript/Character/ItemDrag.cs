using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public string ItemName;
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<Image>().raycastTarget = false;
        this.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        EventManger.instance.TriggerEventListener<string>("ItemDrag", ItemName);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<Image>().raycastTarget = true;
        this.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        EventManger.instance.TriggerEventListener<string>("ItemDrag", "NULL");
    }
}
