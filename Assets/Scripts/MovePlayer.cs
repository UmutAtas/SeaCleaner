using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private DragObject dragObject;
    public float speed;

    private void Awake()
    {
        dragObject = GetComponent<DragObject>();
    }

    private void Update()
    {
        float moveAmountX = dragObject.MoveFactorX   * Time.deltaTime * speed;
        float moveAmountZ = dragObject.MoveFactorZ   * Time.deltaTime * speed;
        transform.Translate(moveAmountX, 0, moveAmountZ);
    }
}
