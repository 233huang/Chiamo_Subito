using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public RectTransform h;
    public RectTransform min;
    public GameObject NOTE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (-0.16<h.rotation.z&&h.rotation.z<-0.09)
        {
            if (0.37<min.rotation.z &&min.rotation.z< 0.43)
            {
                NOTE.SetActive(true);
                Destroy(this);
            }
        }
    }

}
