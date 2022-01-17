using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 视角切换——相机/显示大物体
/// </summary>
public class OtherViewControl : MonoBehaviour
{
    public GameObject MainCamera;//主相机
    public GameObject OtherCamera;//第一视角相机
    public GameObject LeaveBtn;//退出视角切换按钮

    private GameObject show;

    void Start()
    {
        if(LeaveBtn==null)
            LeaveBtn = GameObject.Find("OtherView_RemoveBtn");

        EventManger.instance.AddEventListener<GameObject>("OtherView", OtherView);
        EventManger.instance.AddEventListener("OtherView_RemoveBtn", RemoveBtn);
    }

    void OtherView(GameObject g)
    {
        if (g.GetComponent<OtherView_item>().show != null)
        {
            this.show = g.GetComponent<OtherView_item>().show;
            show.SetActive(true);
        }
        else
        {
            OtherCamera.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, -1);
            OtherCamera.SetActive(true);
            MainCamera.SetActive(false); 
        }
        LeaveBtn.SetActive(true);
    }

    void RemoveBtn()
    {
        if (show != null)
        {
            show.SetActive(false);
            show = null;
        }
        else
        {
            MainCamera.SetActive(true);
            OtherCamera.SetActive(false);
        }
        LeaveBtn.SetActive(false);
    }
}
