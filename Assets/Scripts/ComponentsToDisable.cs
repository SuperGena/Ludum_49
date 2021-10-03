using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ComponentsToDisable : MonoBehaviour
{
    private PhotonView view;
    private Camera camera;
    void Start()
    {
        view = GetComponent<PhotonView>();
        camera = transform.GetChild(1).GetComponent<Camera>();

        if (!view.IsMine)
        {
            camera.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
