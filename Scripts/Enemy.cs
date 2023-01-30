using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed;
   public bool faceleft = true;
   
   private CharacterController2D controller; 
    
   

    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = speed*Time.fixedDeltaTime;
        if(faceleft)
        {
            horizontalMove *= -1.0f;
        }
        controller.Move(horizontalMove,false,false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="TurnAround")
        {
            faceleft = !faceleft;
        } else if (collision.gameObject.tag=="Player")
        {
            SoundManager.S.PlayerSound();
            Debug.Log("Goodbye Cruel World!!!");

            GameManager.S.points += 100;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("Dying");
            speed = 0;

            Destroy(this.gameObject,1.0f);
        }
    }

    
 
}

