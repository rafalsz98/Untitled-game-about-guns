using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 Offset;
    public float SmoothSpeed = 0.125f; 

    private Vector3 currentVelocity = Vector3.zero;   
    
    private void FixedUpdate() 
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + Offset, ref currentVelocity, SmoothSpeed);
    }
}
