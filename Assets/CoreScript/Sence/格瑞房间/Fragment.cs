using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fragment : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public int id=-1;
    public Vector3 initial = Vector3.zero;
    private TreasureChest treasure;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (id == -1)
            this.transform.position = eventData.position;
        else
            this.transform.position = treasure.SetPosition(eventData.position, id);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(id !=-1)
            treasure.SetResult(eventData.position, id);
    }

    // Start is called before the first frame update
    void Start()
    {
        initial = this.transform.position;
        treasure = this.transform.parent.parent.GetComponent<TreasureChest>();
    }

    private void OnEnable()
    {
        if(initial != Vector3.zero)
            this.transform.position = initial;
    }

}
