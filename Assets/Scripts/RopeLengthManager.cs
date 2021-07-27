using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeLengthManager : MonoBehaviour
{
    public ObiRopeCursor cursor;
    public ObiRope rope;
    private DragObject dragObject;
    private Vector3 lengthAmount;
    public float speed;

    private void Awake()
    {
        dragObject = GetComponent<DragObject>();
    }

    private void Update()
    {
        //float lengthAmountX = dragObject.MoveFactorX;
        //float lengthAmountZ = dragObject.MoveFactorZ;
        //lengthAmount = new Vector3(lengthAmountX, 0f, lengthAmountZ);
        //var newLength = lengthAmount.magnitude;
        if (Input.GetMouseButton(0))
        {
            cursor.ChangeLength(rope.restLength + speed * Time.deltaTime);
        }
        else
        {
            cursor.ChangeLength(rope.restLength -1 * Time.deltaTime);
        }
        
    
        
        
      
    }
}
