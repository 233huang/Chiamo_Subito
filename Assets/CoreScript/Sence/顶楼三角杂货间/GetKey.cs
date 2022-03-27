using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public GameObject showkey;
    public void AddKey()
    {
        ItemManager.instance.AddItem("Key");
        showkey.SetActive(true);
    }
}
