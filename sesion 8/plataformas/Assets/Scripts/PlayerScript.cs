using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRB;
    float speed = 5;
    float move;
    bool lookRight = true;
    SpriteRenderer myRender;
    Animator animatorSetting;//definimos componente animator para pasarle las variables de las conmdiciones
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        myRender = GetComponent<SpriteRenderer>();
        animatorSetting = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Movements();        
    }

    private void Movements() {

        move = Input.GetAxis("Horizontal");

        if (move > 0 && !lookRight)
        {
            turn();        
            
        }
        else
        {
            if (move < 0 && lookRight) {
                turn();
            }
        }

        //le damos speed a velocity para que realice el movimiento, en el eje y no varia.
        playerRB.velocity = new Vector2(move * speed, playerRB.velocity.y);
        Debug.Log("move: "+move);
        animatorSetting.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    void turn() {

       myRender.flipX = !myRender.flipX;
       lookRight = !lookRight;      
    }
}
