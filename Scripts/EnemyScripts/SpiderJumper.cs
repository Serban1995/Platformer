using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiderJumper : MonoBehaviour
{
   private Rigidbody2D myBody;
   private Animator anim;
   
   [SerializeField] private float minJumpForce = 5f, maxJumpForce = 12f;

   [SerializeField] private float minWaitTime = 1.5f, maxWaitTime = 3.5f;

   private float JumpTimer;

   private bool canJump;

   
   

   private void Awake()
   {
      myBody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      
   }

   private void Start()
   {
      JumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
   }

   private void Update()
   {
      HandleJump();
      HandleAnimation();
   }

   void HandleJump()
   {
      if (Time.time > JumpTimer)
      {
         JumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
         Jump();
         
      }

      if (myBody.velocity.magnitude == 0)
      {
         canJump = true;
      }
   }

   void Jump()
   {
      if (canJump)
      {
         SoundManager.instance.Play_SpiderAttackSound();
         canJump = false;
         myBody.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));
      }
   }


   void HandleAnimation()
   {
      if (myBody.velocity.magnitude == 0) 
         anim.SetBool(TagManager.SPIDER_JUMP_PARAMETER, false);
      else
      {
         anim.SetBool(TagManager.SPIDER_JUMP_PARAMETER,true);
      }
      
   }
}
