using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Item;
    public Dictionary<string, GameObject> ItemDic = new Dictionary<string, GameObject>();
    public static ItemManager instance = null;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddItem(string s)
    {
        if (Plane.GetComponent<Image>().enabled == false)
            Plane.GetComponent<Image>().enabled = true;
        if(s == "PaperTape")
        {
            GameObject item  = Instantiate(Item, Plane.transform);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("xx");
            ItemDic.Add(s, item);
        }
        if(s == "Key")
        {
            GameObject item = Instantiate(Item, Plane.transform);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Key");
            ItemDic.Add(s, item);
        }
        if(s == "Note")
        {
            GameObject item = Instantiate(Item, Plane.transform);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Note");
            ItemDic.Add(s, item);
        }
    }
    public void RemoveItme(string s,int num =1)
    {
        if(s == "PaperTape")
        {
            if (ItemDic.ContainsKey(s))
            {
                Destroy(ItemDic[s]);
                ItemDic.Remove(s);
            }
        }
    }
}
