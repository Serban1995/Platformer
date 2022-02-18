using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalk : MonoBehaviour
{
   [SerializeField] private bool moveLeft;
   [SerializeField] private float maxWalkDistanceValue = 10f;
   [SerializeField] private float moveSpeed = 6f;

   private SpriteRenderer spriteRen;

   private Vector3 tempPos;
   
   private float minWalkX, maxWalkX;

   private void Awake()
   {
      spriteRen = GetComponent<SpriteRenderer>();
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
      spriteRen.flipX = moveLeft;

      if (tempPos.x < minWalkX)
         moveLeft = false;
      

      if (tempPos.x > maxWalkX)
         moveLeft = true;

   }
   
}
