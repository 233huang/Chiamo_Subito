using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public void AddKey()
    {
        ItemManager.instance.AddItem("Key");
    }
}
