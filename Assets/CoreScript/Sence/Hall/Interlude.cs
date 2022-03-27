using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Interlude : MonoBehaviour,IPointerClickHandler
{
    public CinemachineVirtualCamera cinemachine;
    public Light2D light2D;
    public GameObject[] roles;
    public Text text;
    public Image leftRole;
    public Image rightRole;
    public Sprite[] roleSprites;
    public GameObject course;

    private Image DialogImage;
    private string[] dialogs;
    private int index = 0;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        DialogImage = this.GetComponent<Image>();
        roles[5] = GameObject.Find("LiAng(Clone)");
        roles[6] = GameObject.Find("LiLiAn(Clone)");
        #region 对话内容

        dialogs = new string[16];
        dialogs[0] = "格瑞：又来了又来了，对吧，到底是谁派你们来剽窃我们的试验品？";
        dialogs[1] = "里昂：不是我，这，不是，我说，什么剽窃？你们是谁啊？还有，你又是谁？";
        dialogs[2] = "薇薇安：嘿！你怎么那么没有礼貌呢？什么叫你又是谁！你不认识我？我是大名鼎鼎的薇薇安记者！";
        dialogs[3] = "里昂：不认识。";
        dialogs[4] = "贝尔鲁：不要狡辩了，潜入实验室的小偷们。";
        dialogs[5] = "薇薇安：原来你才是最没礼貌的，你们是谁我不清楚，这是什么实验室我也不清楚，我就是接了一个电话！";
        dialogs[6] = "亚蒙：那么多人来剽窃资料，谁不是把事情撇的一干二净…不用跟他们废话了，叫警察来吧。";
        dialogs[7] = "里昂：喂，我真的不认识你们啊！";
        dialogs[8] = "薇薇安：什么资料我不清楚，我要离开这里！";
        dialogs[9] = "穆齐：两位年轻人，别急着离开，来这里的人都对实验室很感兴趣，给你们一些时间，看能不能找到证明你们清白的证据。";
        dialogs[10] = "贝尔：小朋友们，尽管做吧，能把资料带走算你们厉害。";
        dialogs[11] = "里昂：薇薇安小姐？看来我们要“并肩作战”了。";
        dialogs[12] = "薇薇安：好吧，勉为其难和你合作一下，刚才我说的你也听到了，我是一名记者，你不要拖我后腿哦！";
        dialogs[13] = "里昂：那可说不准，薇薇安记者可不要输给一个私家侦探。";
        dialogs[14] = "薇薇安：合作愉快。";
        dialogs[15] = "里昂：合作愉快。";

        #endregion

        dialogupdate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        dialogupdate();
    }

    public void dialogupdate()
    {
        if(index == 16)
        {
            SetFllow(roles[5 + PlayerManager.instance.CharacterID]);
            course.SetActive(true);
            Destroy(this.transform.parent.gameObject);
            light2D.intensity = 1;
            return;
        }

        text.text = dialogs[index];
        switch (index)
        {
            case 0:
                ChangeDialog(2,2);
                break;

            case 1:
                if(roles[5] == null)
                    roles[5] = GameObject.Find("LiAng(Clone)");
                ChangeDialog(5, 7);
                break;

            case 2:
                if(roles[6] == null)
                    roles[6] = GameObject.Find("LiLiAn(Clone)");
                ChangeDialog(6, 8);
                break;

            case 3:
                ChangeDialog(5, 5);
                break;

            case 4:
                ChangeDialog(1, 1);
                break;

            case 5:
                ChangeDialog(6, 8);
                break;

            case 6:
                ChangeDialog(0, 0);
                break;

            case 7:
                ChangeDialog(5, 7);
                break;

            case 8:
                ChangeDialog(6, 8);
                break;

            case 9:
                ChangeDialog(3, 3);
                break;

            case 10:
                ChangeDialog(1, 1);
                break;

            case 11:
                for (int i = 0; i <= 4; i++)
                {
                    Destroy(roles[i]);
                }
                ChangeDialog(5, 5);
                break;

            case 12:
                ChangeDialog(6, 6);
                break;

            case 13:
                ChangeDialog(5, 5);
                break;

            case 14:
                ChangeDialog(6, 6);
                break;

            case 15:
                ChangeDialog(5, 5);
                break;
        }
        index++;
    }

    
    private void ChangeDialog(int RoleID,int SpieteID)
    {
        StartCoroutine(Follow());

        leftRole.sprite = roleSprites[SpieteID];
        SetFllow(roles[RoleID]);
        leftRole.sprite = roleSprites[SpieteID];
        leftRole.SetNativeSize();
    }
    
      
    IEnumerator Follow()
    {
        ShowDialog(false);
        yield return new WaitForSeconds(1);
        ShowDialog(true);
    }

    public void SetFllow(GameObject g)
    {
        cinemachine.Follow = g.transform;
    }

    private void ShowDialog(bool b)
    {
        light2D.intensity = b ? 0.5f : 1;
        leftRole.enabled = b;
        rightRole.enabled = b;
        DialogImage.enabled = b;
        text.enabled = b;
    }
    

}
