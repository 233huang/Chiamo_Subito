using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BottleClick : MonoBehaviour,IPointerClickHandler
{
    public bool isclick;
    public string BottleName;
    public UnityAction<BottleClick> BottleAction;

    private void Start()
    {
        BottleName = this.gameObject.name;
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isclick)
        {
            SetImageColor(new Color(1f, 1f, 1f));
            isclick = false;
        }
        else
        {
            SetImageColor(new Color(0.5f, 0.5f, 0.5f));
            isclick = true;
        }
        BottleAction?.Invoke(this);
    }

    public void SetImageColor(Color color)
    {
        this.GetComponent<Image>().color = color;
    }
}
