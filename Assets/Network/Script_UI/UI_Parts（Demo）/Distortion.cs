using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distortion : MonoBehaviour
{
    private Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar = this.GetComponent<Scrollbar>();
        scrollbar.onValueChanged.AddListener((f) => { EventManger.instance.TriggerEventListener<float>("Distortion",f); });
    }
}
