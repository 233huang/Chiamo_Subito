using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject Plane;
    public GameObject BGPlane;
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
        BGPlane.SetActive(true);
        Plane.GetComponent<Image>().enabled = true;
        GameObject item = Instantiate(Item, Plane.transform);
        switch (s)
        {
            case "PaperTape":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("xx");
                break;
            case "Key":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Key");
                break;
            case "Note":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Note");
                break;
            case "华钥匙":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/华钥匙");
                break;
            case "实验室的掉落钥匙":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/实验室的掉落钥匙");
                break;
            case "背包中的废纸团":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/背包中的废纸团");
                break;
            case "骰子":
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/骰子");
                break;
        }
        item.AddComponent<ItemDrag>().ItemName = s;
        ItemDic.Add(s, item);
    }
    public void RemoveItme(string s,int num =1)
    {
        if (ItemDic.ContainsKey(s))
        {
            Destroy(ItemDic[s]);
            ItemDic.Remove(s);
        }
    }
}
