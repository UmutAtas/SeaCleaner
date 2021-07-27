using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    private float lastFrameFingerPositionZ;
    private float moveFactorX;
    private float moveFactorZ;
    public float MoveFactorX => moveFactorX;
    public float MoveFactorZ => moveFactorZ;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
            lastFrameFingerPositionZ = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
            moveFactorZ = Input.mousePosition.y - lastFrameFingerPositionZ;
            lastFrameFingerPositionZ = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            moveFactorZ = 0f;
        }
    }
}
