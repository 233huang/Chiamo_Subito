using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 一个简单的控制移动脚本
/// </summary>
namespace Com.MyCompany.MyGame
{
    public class PlayControl : MonoBehaviourPun
    {
        [SerializeField]
        private float speed = 2.3f;
        [SerializeField]
        private AudioDistortionFilter distortionFilter;
        private AudioReverbFilter reverbFilter;
        [SerializeField]
        private Animator animator;

        public bool[] allowControl;
        private void Awake()
        {
            distortionFilter = this.transform.Find("Speaker").gameObject.GetComponent<AudioDistortionFilter>();
            //DontDestroyOnLoad(this.gameObject);
            EventManger.instance.AddEventListener<float>("Distortion", Distortion);
            EventManger.instance.AddEventListener("DeletePlayer", DestoryMyselft);
            animator = this.transform.Find("Sprite").GetComponent<Animator>();

            allowControl = new bool[10];
        }

        private void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            #region 角色控制
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 1);
                this.transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
                animator.SetBool("ismove", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 1);
                this.transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
                animator.SetBool("ismove", true);
            }
            if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("ismove", false);
            }
            if (Input.GetKey(KeyCode.E))
            {
                EventManger.instance.TriggerEventListener("pickup");
            }
            if (Input.GetKey(KeyCode.Y))
            {
                EventManger.instance.TriggerEventListener("DecreaseTime");
            }
            #endregion
        }

        private void DestoryMyselft()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            Destroy(this);
        }

        private void Distortion(float f)
        {
            distortionFilter.distortionLevel = f;
        }
        private void ReverbFilter(int i)
        {
            reverbFilter.reverbPreset = (AudioReverbPreset)i;
        }

    }
}