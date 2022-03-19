using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BluePageLog : MonoBehaviour,IPointerClickHandler
{
    public Text dialogue;
    private string[] DialogueContent;
    private int index = 0;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        DialogueContent = new string[3];
        DialogueContent[0] = "薇薇安：这好像是……设计图纸？";
        DialogueContent[1] = "薇薇安：算是一种线索，但是设计者又是谁呢？";
        DialogueContent[2] = "薇薇安：只能再观察观察……";
        dialogue.text = DialogueContent[index];
        index++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(index == 3)
        {
            this.gameObject.SetActive(false);
            PlayerManager.instance.SetLight_Item(1, false);
        }
        else
        {
            dialogue.text = DialogueContent[index];
            index++;
        }
    }

}
