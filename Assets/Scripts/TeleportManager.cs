using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportManager : MonoBehaviour
{
   #region Singleton
   private static TeleportManager _instance;

   public static TeleportManager Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = GameObject.FindObjectOfType<TeleportManager>();
         }

         return _instance;
      }
   }
   #endregion
   public Transform teleportLocation;
   public bool isShip = false;
   public int collectedTrash;

   private void Awake()
   {
      isShip = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Trash"))
      {
         collectedTrash += 1;
         var col = other.gameObject.GetComponent<CapsuleCollider>();
         var rb = other.gameObject.GetComponent<Rigidbody>();
         other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.down;
         other.transform.DOScale(new Vector3(0.2f, 0.4f, 0.2f),1f).OnComplete((() =>
         {
            other.transform.position = teleportLocation.position;
            isShip = true;
            other.transform.DOScale(new Vector3(0.5f, 0.7f, 0.5f),0.1f);
            col.height = 2f;
            rb.constraints = RigidbodyConstraints.None;
         }));
      }
   }
   
   
}
