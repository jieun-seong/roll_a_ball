using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        // position of the camera - position of the player
        offset = transform.position - player.transform.position;
    }

    // Last thing that happens for each frame
    void LateUpdate()
    {
        // position of the camera
        //transform.position = player.transform.position + offset;
    }
}
