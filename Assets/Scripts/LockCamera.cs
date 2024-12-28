using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    private Quaternion camRotation;
    public Transform player;
    public Vector3 offset;
    public float minX, minZ, maxX, maxZ;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position;

        transform.rotation = camRotation;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        transform.position = position;
    }
}
