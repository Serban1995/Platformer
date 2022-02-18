using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWalk : MonoBehaviour
{
   [SerializeField] private bool moveLeft;
   [SerializeField] private float maxWalkDistanceValue = 3f;
   [SerializeField] private float moveSpeed = 6f;

   //private SpriteRenderer spriteRen;
   private Vector3 tempPos;
   private float minWalkX, maxWalkX;

   private void Awake()
   {
      minWalkX = transform.position.x - maxWalkDistanceValue;
      
      maxWalkX = transform.position.x + maxWalkDistanceValue;
   }
   
   private void Update()
   {
      HandleWalkingWithWalkDistance();
   }

   void HandleWalkingWithWalkDistance()
   {
      tempPos = transform.position;
      if (moveLeft)
      {
         tempPos.x -= moveSpeed * Time.deltaTime;
      }
      else
      {
         tempPos.x += moveSpeed * Time.deltaTime;
         
      }

      transform.position = tempPos;
      
      if (tempPos.x < minWalkX)
         moveLeft = false;
      

      if (tempPos.x > maxWalkX)
         moveLeft = true;
      
   }

}
