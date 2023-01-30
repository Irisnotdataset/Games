using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
   public CharacterController2D controller;
   public float speed;

   private float horizontalMove = 0.0f;

   private bool jump = false;
   //private bool attack = false;
   //private bool blink = false;

   private Animator animator;

    /*public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;*/

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove=Input.GetAxisRaw("Horizontal")*speed;

        if(Input.GetButtonDown("Jump"))
        {
           jump=true;
            SoundManager.S.JumpSound();
            animator.SetBool("IsOnGround", false);
        }

        /*if (Input.GetKey("r"))
        {
            StartCoroutine(PlayerAttack());

        }*/


        //Get the approximate direction

        float ourSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(ourSpeed));

        /*Life.text = "Lives:" + Lives.ToString();

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

            }
            else
            {
                Debug.Log("Time's up!");
                TimeLeft = 0;
                TimerOn = false;

                messageoverlay.enabled = true;
                messageoverlay.text = "Time's up!";

                gameState = GameState.gameOver;
                animator.SetTrigger("Death");
                SoundManager.S.DieSound();


            }
        }*/

    }

    private void FixedUpdate()
    {
        
         controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

         jump = false;

         //attack = false;

         //blink = false;
        
    }

    
    /*public IEnumerator OopsState()
    {
        //set the gamestate to oops
        blink = true;
        gameState = GameState.oops;

        //Text Message

        animator.SetBool("Blink", true);

        messageoverlay.enabled = true;
        messageoverlay.text = "Oops!";

        

        //
        yield return new WaitForSeconds(2.0f);

        blink = false;

        messageoverlay.enabled = false;

        
        animator.SetBool("Blink", false);

        GetComponent<Rigidbody2D>().isKinematic = false;

    }*/

    /*public IEnumerator PlayerAttack()
    {
        attack = true;
        SoundManager.S.AttackSound();
        animator.SetBool("IsAttack", true);
        yield return new WaitForSeconds(2.0f);

        animator.SetBool("IsAttack", false);
    }*/

    /*private void GameOverLose()
    {
        gameState = GameState.gameOver;
        GetComponent<Rigidbody2D>().isKinematic = true;
        messageoverlay.enabled = true;
        messageoverlay.text = "You Die";
        animator.SetTrigger("Death");
        SoundManager.S.DieSound();
        //Destroy(this.gameObject);

    }*/

    /*public IEnumerator GameOverState()
    {
        gameState = GameState.gameOver;
        GetComponent<Rigidbody2D>().isKinematic = true;
        messageoverlay.enabled = true;
        messageoverlay.text = "You Die";
        animator.SetTrigger("Death");
        SoundManager.S.DieSound();
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }*/


    /*private void GameOverWin()
    {
        Debug.Log("GameOver Win");
        gameState = GameState.gameOver;
        GetComponent<Rigidbody2D>().isKinematic = true;
        messageoverlay.enabled = true;
        messageoverlay.text = "You win!!!";

        SoundManager.S.WinSound();
    }*/


    /*void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        //string.Format("{0:00}:{1:00}", minutes, seconds)

        TimerTxt.text = "Countdown:" + minutes.ToString() + ":" + seconds.ToString();

    }*/

    public void PlayerLanded()
    {
        animator.SetBool("IsOnGround", true);
    }

    public void Notattack()
    {
        animator.SetBool("IsAttack", false);
    }

    public void NotDie()
    {
        animator.SetBool("Blink", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Die")
        {

            StartCoroutine(GameManager.S.GameOverState());
            SoundManager.S.StopAllSounds();

        }

        if (collision.gameObject.tag == "Princess")
        {
            
            StartCoroutine(GameManager.S.LevelComplete());
        }

        if (collision.gameObject.tag == "Chest")
        {
            SoundManager.S.ChestSound();
            Destroy(collision.gameObject);
            GameManager.S.Lives++;
            
        }

        if(collision.gameObject.tag=="Next")
        {
            StartCoroutine(GameManager.S.LevelComplete());
            GameManager.S.GameOverWin();
        }

    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.gameObject.tag=="Enemy")
        {
            GetComponent<Rigidbody2D>().isKinematic = true;


            Destroy(collision.gameObject);
            SoundManager.S.DieSound();

            GameManager.S.Lives -=1;
            Debug.Log("Lives is " + GameManager.S.Lives.ToString());
            GameManager.S.Life.text = "Lives:" + GameManager.S.Lives.ToString();

            
            if (GameManager.S.Lives < 1)
            {
                StartCoroutine(GameManager.S.GameOverState());
            }

            else
            {
                StartCoroutine(GameManager.S.OopsState());

            }
            
            
        }
    }
}
