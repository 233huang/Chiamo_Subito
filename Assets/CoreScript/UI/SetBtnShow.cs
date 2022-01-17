using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetBtnShow : MonoBehaviour
{
    public GameObject btn;
    private void OnEnable()
    {
        btn.SetActive(true);
    }
}
