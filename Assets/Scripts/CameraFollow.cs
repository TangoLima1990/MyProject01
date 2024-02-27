using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private Vector3 offSet;
    [SerializeField]private float cameraSpeed;
    

    // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offSet, Time.deltaTime * cameraSpeed);
        }
}
