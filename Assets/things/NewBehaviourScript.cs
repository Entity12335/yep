using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;

    public float movespeed;
    public float jumpForce;
    private bool isInAir;
    private float move;
    private float jump;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        isInAir = false;

        movespeed = 2;
        jumpForce = 2;

    }
    
    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");
    }

    void fixedUpdate()
    {
        if(move != 0f)
        {
            rb2D.AddForce(new Vector3(move * movespeed, 0f), ForceMode2D.Impulse);
        }
        if(!isInAir && jump > 0f)
        {
            rb2D.AddForce(new Vector3(0f, jump * jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "platform")
        {
            isInAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            isInAir = true;
        }
    }
}
