using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class bottle_experiment : MonoBehaviour
{
    public GameObject notebook;
    public Image[] results;
    public Button reward;
    [SerializeField]
    List<BottleClick> bottleclickorder = new List<BottleClick>();

    private int step = 0;
    private UnityAction updateAction;
    private string[][] correctsteps = new string[][]{
        new string[]{ "矮子蓝瓶", "红滴管-棕色瓶" },
        new string[]{ "蓝盖子瓶", "黄色圆瓶","浅蓝色水" },
        new string[]{ "红滴管-棕瓶", "三角橙红色瓶" }
    };

    public void ClickBook()
    {
        Debug.Log("点击了笔记本：bottleclickorder.Count="+ bottleclickorder.Count);
        bool result = true;
        if (bottleclickorder.Count == 0)
            return;
        if (bottleclickorder.Count != correctsteps[step].Length)
            result = false;
        else
        {
            for (int i = 0; i < bottleclickorder.Count; i++)
            {
                Debug.Log("比较：" + bottleclickorder[i].BottleName + "：：：" + correctsteps[step][i]);
                if (bottleclickorder[i].BottleName != correctsteps[step][i])
                    result = false;
            }
        }

        if (result)
            SetSuccess();
        else
            SetFile();
        ClearBottleList();
    }

    public void SetSuccess()
    {
        Debug.Log("成功！"+step);
        notebook.transform.GetChild(step + 5).gameObject.SetActive(true);
        step++;
        updateAction = () =>
        {
            results[step].color += new Color(1, 1, 1, 2 * Time.deltaTime);
            Debug.Log(results[0].color.a);
            if (results[step].color.a >= 1)
            {
                updateAction = null;
            }
        };
    }
    public void SetFile()
    {
        Debug.Log("失败！");
        updateAction = () =>
        {
            results[0].color += new Color(1, 1, 1, 2 * Time.deltaTime);
            Debug.Log(results[0].color.a);
            if (results[0].color.a >= 1)
            {
                updateAction = null;
            }
        };
    }

    public void BottleClickAction(BottleClick bottleClick)
    {
        if (bottleClick.isclick)
            bottleclickorder.Add(bottleClick);
        else
            bottleclickorder.Remove(bottleClick);
    }

    public void ClearBottleList()
    {
        foreach(BottleClick b in bottleclickorder)
        {
            b.isclick = false;
            b.SetImageColor(new Color(1f, 1f, 1f));
        }
        bottleclickorder.Clear();
    }

    private void Start()
    {
        foreach(BottleClick bottleClick in this.transform.GetComponentsInChildren<BottleClick>())
        {
            bottleClick.BottleAction = BottleClickAction;
        }
        notebook.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(()=>ClickBook());
        reward.onClick.AddListener(() =>
        {
            step = 0;
            ClearBottleList();
            foreach(Image r in results)
            {
                r.color = new Color(1, 1, 1, 0);
            }
        });
    }

    public void Update()
    {
        if (updateAction!=null)
            updateAction?.Invoke();
    }
}
