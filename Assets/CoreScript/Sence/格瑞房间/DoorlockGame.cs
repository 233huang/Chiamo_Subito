using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorlockGame : MonoBehaviour
{
    private int index=0;
    public RectTransform point;
    public Image lockstatus;
    public Sprite[] result;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(point.anchoredPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        point.anchoredPosition = new Vector2(point.anchoredPosition.x + Time.deltaTime * speed, point.anchoredPosition.y);
        if (point.anchoredPosition.x >= 308)
            speed = -500;
        if (point.anchoredPosition.x <= -175)
            speed = 500;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(-76<point.anchoredPosition.x&& point.anchoredPosition.x < -45)
            {
                if (index < 2)
                {
                    lockstatus.sprite = result[index];
                    index++;
                }else if(index== 2)
                {
                    this.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
                    this.transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }
}
