using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool doubleJumping;

    private Rigidbody2D rig;
    private Animator anim;

    bool isBlowing;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //move personagem em uma posição
        //transform.position += movement * Time.deltaTime * speed;

        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJumping = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJumping)
                {
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJumping = false;
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D other){

        if(other.gameObject.layer == 11){
            isBlowing = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other) {

        if(other.gameObject.layer == 11){
            isBlowing = false;
        }
        
    }

}
