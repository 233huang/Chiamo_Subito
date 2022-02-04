using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnDoorLock : MonoBehaviour,IDragHandler
{
    [SerializeField] private Canvas m_Canvas;

    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }

    private Vector3? CalculateWorldToScreenPos(Vector3 worldPos)
    {
        if (m_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            return m_Canvas.worldCamera.WorldToScreenPoint(worldPos);
        }
        else if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            Vector3 screenPos = m_Canvas.transform.InverseTransformPoint(worldPos);
            var rectTrans = m_Canvas.transform as RectTransform;
            screenPos.x += rectTrans.rect.width * 0.5f * rectTrans.localScale.x;
            screenPos.y += rectTrans.rect.height * 0.5f * rectTrans.localScale.y;
            return screenPos;
        }

        return null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        //计算当前物体距离画布左下角位置
        Vector3? curScreenPos = CalculateWorldToScreenPos(transform.position);
        if (curScreenPos == null) return;
        //鼠标位置偏移量
        Vector2 offset = eventData.position - (Vector2)curScreenPos.Value;
        if (offset != Vector2.zero)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, offset);
        }
    }
}
