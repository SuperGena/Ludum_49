using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ComponentsToDisable : MonoBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    private PhotonView view;
    [SerializeField] private Camera camera;
    void Start()
    {
        view = GetComponent<PhotonView>();
        camera = transform.GetChild(1).GetComponent<Camera>();

        if (!view.IsMine)
        {
            camera.gameObject.SetActive(false);
            Disable();
        }
    }

    void Disable()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].gameObject.SetActive(false);
        }
    }
}
