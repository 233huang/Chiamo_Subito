using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teach : MonoBehaviour
{
    #region Control GameObject
    private GameObject player;

    private GameObject A;
    private GameObject D;
    private GameObject E;
    private GameObject Y;
    private GameObject Mouse;
    private void Awake()
    {
        A = this.transform.GetChild(0).gameObject;
        D = this.transform.GetChild(1).gameObject;
        E = this.transform.GetChild(2).gameObject;
        Y = this.transform.GetChild(3).gameObject;
        Mouse = this.transform.GetChild(4).gameObject;
    }

    #endregion

    bool[] tk = new bool[4];

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartTeach();
    }
    void StartTeach()
    {
        ChangeImage(A, true);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<PlayControl>().allowControl[0] = true;
            if (!tk[0]) {
                //ChangeImage(A, false);
                tk[0] = true;
                ChangeImage(D, true);
            }
        }
        if (Input.GetKey(KeyCode.D)&&tk[0])
        {
            player.GetComponent<PlayControl>().allowControl[1] = true;
            if (!tk[1])
            {
                //ChangeImage(D, false);
                tk[1] = true;
                ChangeImage(E, true);
            }
        }
        if (Input.GetKey(KeyCode.E) && tk[1])
        {
            player.GetComponent<PlayControl>().allowControl[2] = true;
            if (!tk[2])
            {
                //ChangeImage(D, false);
                tk[2] = true;
                ChangeImage(Y, true);
            }
        }
        if (Input.GetKey(KeyCode.Y) && tk[2])
        {
            if (!tk[3])
            {
                player.GetComponent<PlayControl>().allowControl[3] = true;
                //ChangeImage(D, false);
                tk[3] = true;
                ChangeImage(Mouse, true);
            }
        }
    }

    void ChangeImage(GameObject g,bool ischange)
    {
        Debug.Log(g.name);
        g.GetComponent<Teach_Image>().chance(ischange);
    }
}
