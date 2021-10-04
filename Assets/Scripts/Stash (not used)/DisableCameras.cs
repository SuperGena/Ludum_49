using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DisableCameras : MonoBehaviour
{
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
}
