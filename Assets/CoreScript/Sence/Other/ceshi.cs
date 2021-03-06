using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ceshi : MonoBehaviour,IDragHandler
{
    public InputField text;

    private void Start()
    {
        text.onValueChanged.AddListener((s) => {
            if (s == "0")
                return;
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayControl>().speed = int.Parse(s);
            });
    }
    public void load1()
    {
        SenceLoadManager.instance.LoadSence("Hall", PlayerManager.instance.PlayerCreatVector["Hall"][0]);
    }
    public void load2()
    {
        SenceLoadManager.instance.LoadSence("Level1", PlayerManager.instance.PlayerCreatVector["Level1"][0]);
    }
    public void load3()
    {
        SenceLoadManager.instance.LoadSence("顶楼三角杂货间", PlayerManager.instance.PlayerCreatVector["顶楼三角杂货间"][0]);
    }
    public void load4()
    {
        SenceLoadManager.instance.LoadSence("二楼阳台", PlayerManager.instance.PlayerCreatVector["二楼阳台"][0]);
    }
    public void load5()
    {
        SenceLoadManager.instance.LoadSence("格瑞实验室", PlayerManager.instance.PlayerCreatVector["格瑞实验室"][0]);
    }
    public void load6()
    {
        SenceLoadManager.instance.LoadSence("华森特房间", PlayerManager.instance.PlayerCreatVector["华森特房间"][0]);
    }
    public void load7()
    {
        SenceLoadManager.instance.LoadSence("格瑞房间", PlayerManager.instance.PlayerCreatVector["格瑞房间"][0]);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
}
