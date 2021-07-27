using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
   public Rigidbody rb;
   public float depthBeforeSubmerged = 1f;
   public float displacementAmount = 3f;
   public int floaterCount = 1;
   public float waterDrag = 0.99f;
   public float waterAngularDrag = 0.5f;
   private EndGame endGame;

   private void Awake()
   {
       endGame = FindObjectOfType<EndGame>();
   }

   private void FixedUpdate()
   {
      rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
      
      float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);               
      if (transform.position.y < waveHeight)
      { 
          float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;;
          rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),transform.position,ForceMode.Acceleration);
          rb.AddForce(-rb.velocity * displacementMultiplier * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
          rb.AddTorque(-rb.angularVelocity * displacementMultiplier * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
      }
   }

   private void Update()
   {
       if (endGame.gameEnd == true && gameObject.CompareTag("Trash") && !TeleportManager.Instance.isShip)
       {
           rb.constraints = RigidbodyConstraints.None;
           rb.constraints = RigidbodyConstraints.FreezeRotation;
       }
   }
}
