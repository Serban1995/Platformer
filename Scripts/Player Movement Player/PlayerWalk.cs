using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 6f, jumpForce = 10f;

    private Rigidbody2D myBody;
    
    private Vector3 tempPos;

    private PlayerAnimation playerAnim;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform groundCheckPos;
    
    

    private BoxCollider2D boxCol2D;
    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        boxCol2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
        HandlePlayerAnimations();
        HandleJumping();
    }

    private void FixedUpdate()
    {
        HandleMovementWithRigidBody();
    }

    void HandleMovementWithRigidBody()
    {
        tempPos = transform.position;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        else
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
            

        
    }

    void HandlePlayerAnimations()
    {
        playerAnim.Play_WalkAnimation((int)Mathf.Abs(myBody.velocity.x));
        playerAnim.SetFacingDirection((int)myBody.velocity.x);
        playerAnim.Play_JumpAnimation(!IsGrounded());
    }

    bool IsGrounded()
    {
        
        return Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void HandleJumping()
    {
        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if (IsGrounded())
            {
                SoundManager.instance.Play_PlayerJumpSound();
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(TagManager.ENEMY_TAG))
            GamePlayController.instance.GameOver(false);
        if(col.CompareTag(TagManager.GOAL_TAG))
            GamePlayController.instance.GameOver(true);
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag(TagManager.ENEMY_TAG))
            GamePlayController.instance.GameOver((false));
        if(col.gameObject.CompareTag(TagManager.GOAL_TAG))
            GamePlayController.instance.GameOver(true);
    }
}
