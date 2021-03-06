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
        public float speed = 4f;
        private AudioDistortionFilter distortionFilter;
        private Animator animator;

        public AudioReverbFilter reverbFilter;
        public bool[] allowControl;
        private void Awake()
        {
            EventManger.instance.AddEventListener<float>("Distortion", Distortion);
            EventManger.instance.AddEventListener("PickUp", PickUp);
            EventManger.instance.AddEventListener<int>("DestoryPlayer", DestoryPlayer);
            EventManger.instance.AddEventListener<bool>("混响男孩", ReverbFilter);

            distortionFilter = this.transform.Find("Speaker").gameObject.GetComponent<AudioDistortionFilter>();
            animator = this.transform.Find("Sprite").GetComponent<Animator>();

            allowControl = new bool[10];
        }

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
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
                //this.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 1);
                this.transform.Translate(Vector3.left * Time.deltaTime * speed);
                
                this.transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
                animator.SetBool("ismove", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //this.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 1);
                this.transform.Translate(Vector3.left * Time.deltaTime * speed);
                this.transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
                animator.SetBool("ismove", true);
            }
            if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("ismove", false);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                PlayVoiceManager.instance.SetTramsmit(!PlayVoiceManager.instance.Transmit);
            }
            #endregion

            if (Input.GetKeyDown(KeyCode.P))
            {
                DontDestroyOnLoad(this);
            }
        }

        private void Distortion(float f)
        {
            distortionFilter.distortionLevel = f;
        }

        private void PickUp()
        {
            if (PlayerManager.instance.CharacterID == 0)
                animator.Play("LiAng_PickUp");
            if (PlayerManager.instance.CharacterID == 1)
                animator.Play("LiLiAn_PickUp");
            AudioManager.instance.PlayUIAudio("Music/拾取");
        }

        private void ReverbFilter(bool b)
        {
            reverbFilter.enabled = b;
        }

        private void DestoryPlayer(int id)
        {
        }
    }
}