using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]


public class SideController2D : MonoBehaviour
{
  

    
    // ground check values
    [Header("Ground Check Values")]
    public float groundCheckRadius = 0f;
    public float groundCheckYOffset = 0f;
    public LayerMask layerMask;

    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GetGroundCheckPosition(), groundCheckRadius, layerMask);

        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }


        // Update is called once per frame
        void Update()
    {
        // Are we stunned?
    }

    private Vector3 GetGroundCheckPosition()
    {
        Vector3 groundCheckPos = transform.position + new Vector3(0, groundCheckYOffset, 0);
        return groundCheckPos;
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(GetGroundCheckPosition(), groundCheckRadius);

    }  
   
}

