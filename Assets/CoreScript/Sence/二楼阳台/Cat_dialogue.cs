using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat_dialogue : MonoBehaviour,IPointerDownHandler
{
    //人物
    public Image LiAn;
    public Image Cat;
    public Sprite[] CharacterSprite;
    //对话
    public Image LiAnText;
    public Image CatText;
    public Sprite[] sprites;
    private bool[] isLiAn = new bool[8] { true, false, true, false, false, true,false,true };
    private int index = 0;
    //猜拳
    public Image Cai;
    public Sprite[] Cat_cai;
    public Toggle[] LiAnCai;
    private bool StratCai; 
    private int caiindex = 0;
    private int LiAnSelect = 1;
    private int result;//1赢 0平 -1败
    //时间
    public Image TimeImage;
    public Sprite[] Time_sprite;
    private float timeer;
    private int timetemp = 1;
    //结果
    public Image resultImage;
    public Sprite[] resultSprites;
    public Button again;
    public Button quit;
    public GameObject key;

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

        again.onClick.AddListener(() => {
            timetemp = 1;
            timeer = 0;
            caiindex = 0;
            foreach (Toggle t in LiAnCai)
            {
                t.gameObject.SetActive(true);
                t.interactable = true;
            }
            Cai.enabled = true;
            resultImage.gameObject.SetActive(false);
            TimeImage.gameObject.SetActive(true);
            again.gameObject.SetActive(false);
            quit.gameObject.SetActive(false);
            StratCai = true;
        });
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
            TimeImage.gameObject.SetActive(true);
            return;
        }
        if (index == 7)
        {
            Cat.enabled = false;
            key.SetActive(true);
        }
        if (index == 8)
        {
            Destroy(this.transform.parent.gameObject);
            ItemManager.instance.AddItem("华钥匙");
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
        if (Cai.sprite == Cat_cai[0])//布
        {
            if(LiAnSelect  == 1)//剪
            {
                result = 1;
            }
            if (LiAnSelect == 2)//布
            {
                result = 0;
            }
            if (LiAnSelect == 3)//拳
            {
                result = -1;
            }
        }
        if (Cai.sprite == Cat_cai[1])//拳头
        {
            if (LiAnSelect == 1)
            {
                result = -1;
            }
            if (LiAnSelect == 2)
            {
                result = 1;
            }
            if (LiAnSelect == 3)
            {
                result = 0;
            }
        }
        if (Cai.sprite == Cat_cai[2])//剪刀
        {
            if (LiAnSelect == 1)
            {
                result = 0;
            }
            if (LiAnSelect == 2)
            {
                result = -1;
            }
            if (LiAnSelect == 3)
            {
                result = 1;
            }
        }

        resultImage.gameObject.SetActive(true);
        Cai.enabled = false;
        foreach (Toggle t in LiAnCai)
        {
            t.gameObject.SetActive(false);
        }
        TimeImage.gameObject.SetActive(false);
        switch (result)
        {
            case 1:
                resultImage.sprite = resultSprites[0];
                CatText.enabled = true;
                CatText.sprite = sprites[6];
                index++;
                break;
            case 0:
                resultImage.sprite = resultSprites[1];
                again.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                break;
            case -1:
                resultImage.sprite = resultSprites[2];
                again.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                break;
        }

    }
}
