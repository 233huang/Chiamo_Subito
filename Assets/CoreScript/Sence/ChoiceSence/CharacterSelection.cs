using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CharacterSelection : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    private Image image;
    private Image introduce;
    private Image selected;
    private Image myselfselected;
    private bool CanSelect;

    public UnityAction<int> OnMouseUp;
    public int roleID;
    public bool roleSelected;
    public ChangeImage tips; 
    

    private void Start()
    {
        image = this.GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.5f;
        introduce = this.transform.GetChild(0).GetComponent<Image>();
        selected = this.transform.GetChild(1).GetComponent<Image>();
        myselfselected = this.transform.GetChild(2).GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (roleSelected)
            return;
        ChangeColorAndIntroduce(true);
        tips.SetSprite(false);
        CanSelect = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (roleSelected)
            return;
        ChangeColorAndIntroduce(false);
        tips.SetSprite(true);
        CanSelect = false;
    }

    public void ChangeColorAndIntroduce(bool OnMouseUp)
    {
        if(OnMouseUp)
        {
            image.color = new Color(1, 1, 1, 1);
            introduce.enabled = true;
        }
        else
        {
            image.color = new Color(0.5f , 0.5f, 0.5f, 1);
            introduce.enabled = false;
        }
    }

    public void SetSelected()
    {
        ChangeColorAndIntroduce(true);
        if (roleID == PlayerManager.instance.CharacterID)
            myselfselected.enabled = true;
        else
            selected.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Debug.Log("CanSelect:" + CanSelect+ "!roleSelected:"+ !roleSelected+ "PlayerManager.instance.CharacterID:"+ PlayerManager.instance.CharacterID);

        if(CanSelect && !roleSelected && PlayerManager.instance.CharacterID == -1)
            OnMouseUp?.Invoke(roleID);
    }
}
