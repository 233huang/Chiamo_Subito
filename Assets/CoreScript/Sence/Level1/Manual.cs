using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    public Button forward;
    public Button back;
    public Image page;
    public Sprite[] sprites;

    private int CurrentPage = 0;
    private int ToNumber;
    private bool startfang = false;
    private bool endfang = false;
    // Start is called before the first frame update
    void Start()
    {
        forward.onClick.AddListener(() => {
            if (startfang || endfang|| CurrentPage + 1 > sprites.Length)
                return;
            ToNumber = CurrentPage + 1;
            PageTurning();
        });
        back.onClick.AddListener(() => {
            if (startfang || endfang|| CurrentPage - 1 < 0)
                return;
            ToNumber = CurrentPage - 1;
            PageTurning();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (startfang)
        { 
            page.color = new Color(1, 1, 1, Mathf.Lerp(page.color.a, 0, Time.deltaTime*2));
            Debug.Log("a:"+page.color.a);
            if (page.color.a <= 0.2)
            {
                Debug.LogError("x");
                startfang = false;
                page.sprite = sprites[ToNumber];
                endfang = true;
            }
        }
        if (endfang)
        {
            page.color = new Color(1, 1, 1, Mathf.Lerp(page.color.a, 1, Time.deltaTime*3));
            if(page.color.a >= 0.9)
            {
                endfang = false;
                CurrentPage = ToNumber;
            }
        }
    }

    void PageTurning()
    {
        startfang = true;
    }
}
