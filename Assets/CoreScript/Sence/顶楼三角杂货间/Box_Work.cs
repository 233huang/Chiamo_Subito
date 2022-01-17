using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Work : MonoBehaviour
{
    public void WorkState()
    {
        Electric_boxManager.instance.Work = !Electric_boxManager.instance.Work;

    }
}
