using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 32f;
    private bool isFacingRight = true;
    public Animator animator;
    private bool wasGrounded;
 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
     void Update()
     {
          horizontal = Input.GetAxisRaw("Horizontal");

          bool isGrounded = IsGrounded();

          if (Input.GetButtonDown("Jump") && IsGrounded())
          {
               rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
               animator.SetBool("isJumping", true);
          }

          if (Input.GetButtonDown("Jump") && rb.linearVelocity.y > 0f)
          {
               rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
          }

          if (!wasGrounded && isGrounded)
          {
               animator.SetBool("isJumping", false);
          }

          wasGrounded = isGrounded;

          Flip();

          animator.SetFloat("Speed", Mathf.Abs(horizontal));
     
   }


     private void FixedUpdate()
     {
          rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
     }

   private bool IsGrounded()
   {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
   }

   private void Flip()
   {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
   }
}