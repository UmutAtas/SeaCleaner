using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveObject : MonoBehaviour
{
    private DragObject dragObject;
    public Rigidbody rb;
    public float speed;
    public Transform targetTransform;
    private EndGame endGame;

    private void Awake()
    {
        dragObject = GetComponent<DragObject>();
        endGame = FindObjectOfType<EndGame>();
    }

    private void Update()
    {
        rb.AddForce((targetTransform.position-transform.position).normalized * speed);
        if (endGame.gameEnd == true)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        /*float moveAmountX = dragObject.MoveFactorX * Time.deltaTime;
        float moveAmountZ = dragObject.MoveFactorZ * Time.deltaTime;
        transform.Translate(moveAmountX, 0, moveAmountZ);*/
    }
    
}
