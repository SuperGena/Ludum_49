using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

    public class GetPlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool FireWeapon { get; private set; }

        public event Action OnFire = delegate { };

        public Camera camera;
        
        private PhotonView view;

        private void Start()
        {
            view = GetComponent<PhotonView>();
            
            if (!view.IsMine)
            {
                camera.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (view.IsMine)
            {
                Horizontal = Input.GetAxis("Horizontal");
                Vertical = Input.GetAxis("Vertical");
                FireWeapon = Input.GetKey(KeyCode.Mouse0);

                if (FireWeapon)
                {
                    OnFire();
                }
            }
            else
            {
                return;
            }
        }
    }
