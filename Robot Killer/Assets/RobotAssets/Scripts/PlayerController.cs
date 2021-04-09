using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{


        private Animator anim;
        Rigidbody rb;

        [SerializeField]
        private float speed, isWalk;

        [SerializeField]
        private Vector2 moveVector;

    IEnumerator AnimationTurn(float x)
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isTurn", false);
        transform.rotation = Quaternion.Euler(0f, x, 0f);
    }
    private void Start()

        {
             
            anim = GetComponent<Animator>();

            
            rb = GetComponent<Rigidbody>();
       

        }

    
    public void Update()
    {


        Walk();

        Flip();

    }



    void Walk()
    {
       
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        if (rb.velocity.x != 0)
        {

            anim.SetBool("isWalk", true);


        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    } 

        void Flip()
    {
        
        if (rb.velocity.x > 0)
        {
            
            StartCoroutine(AnimationTurn(90f));       
        }

        else if (rb.velocity.x < 0)
        {
            anim.SetBool("isTurn", true);

            StartCoroutine(AnimationTurn(-90f));


        }


    }
}

