using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camera;

    public float speed;
    public float divider;

    public Vector3 minBound, maxBound;

    private float deltaX = 0;
    private Vector3 targetPos;
    private float startPos;

    public void Update()
    {
        CameraSlider();
    }

    void CameraSlider()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deltaX = Input.mousePosition.x;
            startPos = camera.position.x;
        }
            
        if (Input.GetMouseButton(0))
        {
            float xPos = startPos + (Input.mousePosition.x - deltaX) / divider;
            targetPos = new Vector3(xPos, camera.position.y,
                camera.position.z);
            
        }

        targetPos.x = Mathf.Clamp(targetPos.x, minBound.x, maxBound.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minBound.y, maxBound.y);
        targetPos.z = -10;
        
        camera.transform.position = Vector3.Lerp(camera.position, targetPos, Time.fixedDeltaTime * speed);
    }
}
