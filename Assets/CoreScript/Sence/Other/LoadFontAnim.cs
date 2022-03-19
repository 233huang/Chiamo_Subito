using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadFontAnim : MonoBehaviour
{
    private Text text;
    private char[] content;
    private float Timeer;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        content = text.text.ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        Timeer += Time.deltaTime;
        if (Timeer >= 0.5f)
        {
            if (index % content.Length == 0)
                text.text = "";
            text.text += content[index % content.Length];
            Timeer = 0;
            index++;
        }
    }
}
