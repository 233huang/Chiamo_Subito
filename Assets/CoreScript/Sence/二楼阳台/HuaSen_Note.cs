using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuaSen_Note : MonoBehaviour
{
    public GameObject Note;
    public void ShowNote()
    {
        Note.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void GetNote()
    {
        ItemManager.instance.AddItem("Note");
    }
}
