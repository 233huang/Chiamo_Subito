using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{
    private Vector3 ModelPos;
    private Vector3 oldmousePos;
    private Vector3 newmousePos;
    private float RotateAngle;
    private int forward;

    private void Start()
    {
        ModelPos = this.transform.position;
    }
    private void OnMouseDown()
    {
        Debug.Log(Input.mousePosition);
        oldmousePos = Input.mousePosition;
    }
    /*private void OnMouseDrag()
    {
        newmousePos = Input.mousePosition;

        RotateAngle = Vector2.Angle(oldmousePos - ModelPos, newmousePos - ModelPos);
        
        forward = Quaternion.FromToRotation(oldmousePos - ModelPos, newmousePos - ModelPos).z > 0 ? 4 : -4;
        this.transform.eulerAngles = new Vector3(0,0, this.transform.eulerAngles.z + RotateAngle*5);

        oldmousePos = newmousePos;
    }*/
}
