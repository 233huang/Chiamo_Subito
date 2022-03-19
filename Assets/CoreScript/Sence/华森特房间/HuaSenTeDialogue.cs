using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HuaSenTeDialogue : MonoBehaviour,IPointerClickHandler
{ 
    //人物
    public Image LiAn;
    public Image HuaSenTe;
    public Sprite[] CharacterSprite;
    //对话
    public Text DialogueText;
    public string[] DialogueContent;
    private bool[] LiAnSaying = new bool[7] { false, true, false, false, true, false, false };
    private int index = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(index == 7)
        {
            this.transform.parent.gameObject.SetActive(false);
            PlayerManager.instance.SetLight_Item(1, false);
            index = 0;
        }else    
            ChangeDialog();
    }

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        DialogueContent = new string[7];
        DialogueContent[0] = "华森特：你好，我是贝尔鲁先生的助手，我叫华森特";
        DialogueContent[1] = "里昂：你好，所以床头上的相框是你和贝尔鲁先生的合影吗";
        DialogueContent[2] = "华森特：是的，我十分敬重贝尔鲁先生，他是我的偶像";
        DialogueContent[3] = "华森特：但是最近亚蒙和贝尔鲁先生走的很近";
        DialogueContent[4] = "里昂：亚蒙？";
        DialogueContent[5] = "华森特：是的，红色头发那位，亚蒙是实验楼公开招聘的实习生";
        DialogueContent[6] = "华森特：虽然有点“吃醋”，但是我会在研究上有所突破，做的更好，让贝尔鲁先生对我刮目相看！";
        ChangeDialog();
    }

    void ChangeDialog()
    {
        Debug.Log(index);
        Debug.Log(DialogueContent[0]);
        DialogueText.text = DialogueContent[index];
        if (LiAnSaying[index])
        {
            LiAn.sprite = CharacterSprite[1];
            HuaSenTe.sprite = CharacterSprite[2];
        }
        else
        {
            LiAn.sprite = CharacterSprite[0];
            HuaSenTe.sprite = CharacterSprite[3];
        }
        index++;
    }
}
