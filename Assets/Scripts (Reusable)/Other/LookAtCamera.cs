using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Awake()
    {
        Look();
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector3 myPos = transform.position;
        Quaternion mainCameraRot = Quaternion.identity;
        
        Camera camera = Camera.main;
        if (camera) mainCameraRot = camera.transform.rotation;

        transform.LookAt(myPos + mainCameraRot * Vector3.forward, mainCameraRot * Vector3.up);
    }
}
