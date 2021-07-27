using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterForce : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    private EndGame endGame;

    private void Awake()
    {
        endGame = FindObjectOfType<EndGame>();
    }

    private void Update()
    {
        rb.AddForce(Vector3.forward * force);
        if (endGame.gameEnd == true)
        {
            force = 50f;
        }
    }
}
