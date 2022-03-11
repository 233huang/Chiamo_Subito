using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorlockGame : MonoBehaviour
{
    public RectTransform point;
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
                Debug.Log("按到了！");
            }
        }
    }
}
