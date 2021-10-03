using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GetPlayerInput playerInput;

    public float turnSmoothTime = 0.1f;
    
    float turnSmoothVelocity;
    
    private void Start()
    {
        playerInput = GetComponent<GetPlayerInput>();
    }

    private void Update()
    {
        
        
    }

    void CameraMovement()
    {
        Vector3 direction = new Vector3(playerInput.Horizontal, 0f, playerInput.Vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                            playerInput.camera.transform.eulerAngles.y;
        
        float angle =
            Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        
        //Vector3 moveDir
    }
}
