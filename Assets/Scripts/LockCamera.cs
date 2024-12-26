using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    private Quaternion camRotation;
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camRotation;
        transform.position = player.position;
    }
}
