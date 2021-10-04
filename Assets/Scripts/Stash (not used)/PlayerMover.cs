using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(GetPlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;

        private GetPlayerInput playerInput;
        private CharacterController controller;
        
        
        public float turnSmoothTime = 0.1f;
    
        float turnSmoothVelocity;

        private void Awake()
        {
            playerInput = GetComponent<GetPlayerInput>();
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            //MovePlayer();
            MoveAndRotate();
        }

        void MovePlayer()
        {
            Vector3 movement = transform.position;
            movement += new Vector3(playerInput.Horizontal * Time.deltaTime * speed, 0, playerInput.Vertical * Time.deltaTime * speed) ;
            transform.position = movement;
            
            
            
            
        }

        void MoveAndRotate()
        {
            Vector3 direction = new Vector3(playerInput.Horizontal, 0f, playerInput.Vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                                    playerInput.camera.transform.eulerAngles.y;
        
                float angle =
                    Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
    }
