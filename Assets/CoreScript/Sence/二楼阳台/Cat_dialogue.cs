using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat_dialogue : MonoBehaviour, IPointerDownHandler
{
    //人物
    public Image LiAn;
    public Image Cat;
    public Sprite[] CharacterSprite;
    //对话
    public Text LiAnText;
    public Text CatText;
    public string[] DialogueContent;
    private bool[] LiAnSaying = new bool[9] { true, false, true, false, false, true, false, false,true };
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
    //Cat本体
    public GameObject CatObject;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        int i = 1;
        foreach (Toggle toggle in LiAnCai)
        {
            int temp = i;
            toggle.onValueChanged.AddListener((b) =>
            {
                if (b)
                {
                    LiAnSelect = temp;
                }
            });
            i++;
        }
        again.onClick.AddListener(() =>
        {
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

        DialogueContent = new string[9];
        DialogueContent[0] = "里昂：噢，上帝，这里居然有只猫,你看它洁白的毛发，柔顺又有光泽，这让我想起了我的前女友...";
        DialogueContent[1] = "猫咪：喵喵喵喵喵…喵喵！\n（在这里也太无聊了…陪我玩！）";
        DialogueContent[2] = "里昂：（这么突然？） 好吧，但是玩什么呢？";
        DialogueContent[3] = "猫咪：喵……喵喵喵！ （让本猫想想……就石头剪刀布吧！）";
        DialogueContent[4] = "猫咪：喵喵喵，喵喵 喵喵喵。 （赢了我，我就送你个小礼物）";
        DialogueContent[5] = "里昂：好，开始吧。";
        DialogueContent[6] = "猫咪：喵，喵喵 喵瞄喵 喵 （好吧，猫猫一言，驷马难追）_";
        DialogueContent[7] = "猫咪：喵喵 喵瞄喵 （送你个小礼物，下次再见）_";
        DialogueContent[8] = "里昂:跑的那么快……";
        SetCharacterSprite();
    }

    public void SetCharacterSprite()
    {
        Debug.Log("SetCharacterSprite");
        if(LiAnSaying[index])
        {
            LiAn.sprite = CharacterSprite[1];
            Cat.sprite = CharacterSprite[2];
            LiAnText.enabled = true;
            CatText.enabled = false;
            LiAnText.text = DialogueContent[index];
        }
        else
        {
            LiAn.sprite = CharacterSprite[0];
            Cat.sprite = CharacterSprite[3];
            LiAnText.enabled = false;
            CatText.enabled = true;
            CatText.text = DialogueContent[index];
        }
        index++;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(index < 6 || 6 < index && index != 9)
            SetCharacterSprite();
        else
        {
            if (index == 6)
            {
                LiAnText.enabled = false;
                CatText.enabled = false;
                Cai.enabled = true;
                foreach (Toggle t in LiAnCai)
                {
                    t.gameObject.SetActive(true);
                }
                StratCai = true;
                TimeImage.gameObject.SetActive(true);
                return;
            }
            if (index == 9)
            {
                Destroy(this.transform.parent.gameObject);
                ItemManager.instance.AddItem("华钥匙");
                Destroy(CatObject);
            }
        }
        if(index == 8)
        {
            Cat.enabled = false;
            key.SetActive(true);
        }
    }

    private void Update()
    {
        if (StratCai)
        {
            timeer += Time.deltaTime * 4;
            if (timeer > timetemp)
            {
                Cai.sprite = Cat_cai[caiindex % 3];
                if (caiindex % 4 == 0)
                {
                    TimeImage.sprite = Time_sprite[caiindex / 4];
                }
                caiindex++;
                timetemp++;
            }
            if (caiindex >= 20)
            {
                StratCai = false;
                foreach (Toggle t in LiAnCai)
                {
                    t.interactable = false;
                }
                StartCoroutine("Stop");
            }
        }
    }

    private void Result()
    {
        if (Cai.sprite == Cat_cai[0])//布
        {
            if (LiAnSelect == 1)//剪
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
                SetCharacterSprite();
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

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1.5f);
        Result();
    }
}