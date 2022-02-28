using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat_dialogue : MonoBehaviour,IPointerDownHandler
{
    public Image LiAn;
    public Image Cat;
    public Sprite[] CharacterSprite;

    public Image LiAnText;
    public Image CatText;
    public Sprite[] sprites;

    public Image Cai;
    public Sprite[] Cat_cai;

    public Image TimeImage;
    public Sprite[] Time_sprite;

    public Toggle[] LiAnCai;

    private bool StratCai;
    private float timeer;

    private bool[] isLiAn = new bool[6] { true, false, true, false, false, true };
    private int LiAnSelect = 1;

    private int index=0;
    private int caiindex=0;
    private int timetemp=1;

    private void Start()
    {
        int i = 1;
        foreach(Toggle toggle in LiAnCai)
        {
            int temp = i;
            toggle.onValueChanged.AddListener((b) => { if (b) {
                    LiAnSelect = temp;
                } });
            i++;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (index == 6)
        {
            LiAnText.enabled = false;
            CatText.enabled = false;
            Cai.enabled = true;
            foreach(Toggle t in LiAnCai)
            {
                t.gameObject.SetActive(true);
            }
            StratCai = true;
            return;
        }

        LiAnText.enabled = isLiAn[index];
        CatText.enabled = !isLiAn[index];

        if (LiAnText.enabled)
        {
            LiAn.sprite = CharacterSprite[1];
            Cat.sprite = CharacterSprite[2];
            LiAnText.sprite = sprites[index];
        }
        else {
            LiAn.sprite = CharacterSprite[0];
            Cat.sprite = CharacterSprite[3];
            CatText.sprite = sprites[index];
        }
        index++;
    }

    private void Update()
    {
        if(StratCai)
        {
            timeer += Time.deltaTime*4;
            if (timeer > timetemp)
            {
                Cai.sprite = Cat_cai[caiindex%3];
                if (caiindex%4==0)
                {
                    TimeImage.sprite = Time_sprite[caiindex / 4];
                }
                caiindex++;
                timetemp++;
            }
            if (caiindex >= 20)
            {
                StratCai = false;
                Result();
            } 
        }
    }

    private void Result()
    {
        foreach (Toggle t in LiAnCai)
        {
            t.interactable = false;
        }
        if (Cai.sprite == Cat_cai[0])
        {

        }
        
    }
}
