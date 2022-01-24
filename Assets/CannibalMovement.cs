using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannibalMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectile;
    bool isGrounded;

    Animator m_Animation;

    public float speed = 10f;
    public float jumpheight = 10f;


    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
          isGrounded = false;
          m_Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        DoCollisons();
        DoJump();
        DoMove();




        if (Input.GetButtonDown("Fire1"))
        {
            m_Animation.SetTrigger("Fight");
        }
    }

     void DoCollisons()
    {
        float rayLength = 1f;


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);

        Color hitColor = Color.white;

        isGrounded = false;

        if (hit.collider != null)
        {


            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                hitColor = Color.green;
                isGrounded = true;
            }
            

            Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
        }

    }

     void DoJump()
        {
            Vector2 velocity = rb.velocity;

            // check for jump
            if (Input.GetKey("space") && isGrounded == true)
            {
                if (velocity.y < 0.01f)
                {
                    velocity.y = jumpheight;
                    FindObjectOfType<SoundManagerSingleton>().Play("Shoot");
                    m_Animation.SetTrigger("Jumping");
                }
            }

            rb.velocity = velocity;

        }

      void DoFaceLeft(bool faceleft)
        {
            if (faceleft == true)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    
        void DoMove()
        {
            Vector2 velocity = rb.velocity;

            // stop player sliding when not pressing left or right
            velocity.x = 0;

            // check for moving left
            if (Input.GetKey("a"))
            {
                velocity.x = -speed;
                m_Animation.SetBool("IsMoving", true);
            }

            // check for moving right
            else if (Input.GetKey("d"))
            {
                velocity.x = speed;
                m_Animation.SetBool("IsMoving", true);
            }
            else
            {
                m_Animation.SetBool("IsMoving", false);
            }

           

            if (velocity.x < -0.5f)
            {
                 transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (velocity.x > 0.5f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }



            rb.velocity = velocity;

        }

        public void CreateProjectile()
        {
          FindObjectOfType<SoundManagerSingleton>().Play("Shoot");

        }

        public void Footstep0()
        {
            FindObjectOfType<SoundManagerSingleton>().Play("Footstep0");
        }

         public void Footstep1()
        {
            FindObjectOfType<SoundManagerSingleton>().Play("Footstep1");
        }


}
