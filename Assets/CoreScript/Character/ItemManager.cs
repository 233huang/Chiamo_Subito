using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Item;
    public Dictionary<string, GameObject> ItemDic;
    public static ItemManager instance = null;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddItem(string s)
    {
        if(s == "PaperTape")
        {
            GameObject item  = Instantiate(Item, Plane.transform);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("");
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
