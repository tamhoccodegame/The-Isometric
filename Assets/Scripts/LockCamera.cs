using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    Quaternion initRotation;
    Vector3 initPosition;
    Vector3 offset;
    PhotonView view;
    void Start()
    {
        initRotation = transform.rotation;
        initPosition = transform.position;
        offset = transform.position - transform.parent.position;
        view = GetComponentInParent<PhotonView>();
        if(!view.IsMine) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine) return;
            Vector3 position = transform.parent.position;
            position += offset;

            transform.rotation = initRotation;

            transform.position = position;
    }
}
