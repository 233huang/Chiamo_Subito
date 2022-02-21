using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Box_ItemDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Vector3 offset;
    private RectTransform rt;
    private Vector3 pos;
    private bool DontMove;

    [SerializeField]
    private Vector3 startVector3;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        pos = rt.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        startVector3 = rt.position;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
        {
            //计算UI和指针之间的位置偏移量
            offset = rt.position - globalMousePos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (DontMove)
            rt.position = startVector3;
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        Vector3 globalMousePos;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
        {
            if(!DontMove)
                rt.position = offset + globalMousePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "box"||collision.tag == "item")
        {
            DontMove = true;
        }
        if(collision.tag == "end"&&this.gameObject.name =="key")
        {
            this.transform.parent.gameObject.SetActive(false);
            GameObject.Find("KEYYYY").gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DontMove = false;
    }
}
