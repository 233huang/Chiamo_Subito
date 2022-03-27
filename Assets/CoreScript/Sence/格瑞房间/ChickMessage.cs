using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ChickMessage : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.PlayUIAudio("Music/UI通用");
        this.GetComponent<Animator>().enabled = true;
    }

}
