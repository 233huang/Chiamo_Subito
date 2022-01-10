using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherView_RemoveBtn : MonoBehaviour
{
    GameObject btn;
    private void Start()
    {
        btn = this.gameObject;
        btn.GetComponent<Button>().onClick.AddListener(() => { EventManger.instance.TriggerEventListener("OtherView_RemoveBtn"); });
        btn.SetActive(false);
    }

}
