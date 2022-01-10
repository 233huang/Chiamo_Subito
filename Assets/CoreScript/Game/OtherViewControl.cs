using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherViewControl : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject OtherCamera;
    public GameObject LeaveBtn;


    void Awake()
    {
        LeaveBtn = GameObject.Find("OtherView_RemoveBtn");
        EventManger.instance.RemoveEventListener<Transform>("OtherView", OtherView);
        EventManger.instance.AddEventListener<Transform>("OtherView", OtherView);

        EventManger.instance.RemoveEventListener("OtherView_RemoveBtn", RemoveBtn);
        EventManger.instance.AddEventListener("OtherView_RemoveBtn", RemoveBtn);
    }

    void OtherView(Transform transform)
    {
        Debug.Log("测试2+"+ transform.position);
        OtherCamera.transform.position = new Vector3( transform.position.x,transform.position.y,-1);
        OtherCamera.SetActive(true);
        MainCamera.SetActive(false);
        LeaveBtn.SetActive(true);
    }

    void RemoveBtn()
    {
        Debug.Log("测试3");
        MainCamera.SetActive(true);
        OtherCamera.SetActive(false);
        LeaveBtn.SetActive(false);
    }
}
