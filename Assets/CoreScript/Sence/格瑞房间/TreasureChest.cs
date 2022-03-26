using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : MonoBehaviour
{
    public Transform[] targets;
    private bool comlete;
    private bool[] results = new bool[4];
    public GameObject fragmentParent;
    public Image chest;
    public Image touzi;

    public Vector3 SetPosition(Vector3 v3,int i)
    {
        if (Vector3.Distance(v3, targets[i].position) < 20f)
            return targets[i].position;
        return v3;
    }

    public void SetResult(Vector3 v3,int i)
    {
        if (Vector3.Distance(v3, targets[i].position) < 20f)
            results[i] = true;
        if (results.All((b)=>b==true))
            StartAnim();
    }
    
    private void StartAnim()
    {
        comlete = true;
        Destroy(fragmentParent);
    }

    private void Update()
    {
        if (comlete)
        {
            chest.GetComponent<Image>().color = new Color(1, 1, 1, chest.GetComponent<Image>().color.a - Time.deltaTime);
            if(chest.GetComponent<Image>().color.a<=0.2f)
                touzi.GetComponent<Image>().color = new Color(1, 1, 1, touzi.GetComponent<Image>().color.a + Time.deltaTime);
            if (touzi.GetComponent<Image>().color.a > 0.9f)
            {
                ItemManager.instance.AddItem("骰子");
                Destroy(this);
            }
        }
    }

    private void OnEnable()
    {
        for(int i =0;i<results.Length;i++)
        {
            results[i] = false;
        }
    }
}
