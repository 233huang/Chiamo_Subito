using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
