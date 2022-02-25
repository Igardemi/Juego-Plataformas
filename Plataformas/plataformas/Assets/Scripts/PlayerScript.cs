using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRB;
    float speed = 5;
    float move;
    public float forceJump= 10;
    bool lookRight = true;
    SpriteRenderer myRender;
    Animator animatorSetting;//definimos componente animator para pasarle las variables de las conmdiciones
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        myRender = GetComponent<SpriteRenderer>();
        animatorSetting = gameObject.GetComponent<Animator>();
        //para que no se detecte asi mismo
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animatorSetting.SetFloat("VerticalVelocity", playerRB.velocity.y);
        Debug.Log("Velocidad en y " + playerRB.velocity.y);

        
        if (Input.GetAxis("Jump") > 0 && isGrounded) {
            Debug.Log("hemos pulsado el salto");
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0,forceJump),ForceMode2D.Impulse);
            isGrounded = false; //despega del suelo
            animatorSetting.SetBool("IsGrounded", false);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        // If it hits something...
        if (hit.collider != null && isGrounded==false && playerRB.velocity.y < 0 )
        {
            if (hit.distance < 0.4)
            {
                Debug.Log("Detecto un objeto " + hit.collider.gameObject.name +". A discancia: "+ hit.distance);
                isGrounded = true;
                animatorSetting.SetBool("IsGrounded",true);
            }
        }
       
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
        //Debug.Log("move: "+ move);
        animatorSetting.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    void turn() {

       myRender.flipX = !myRender.flipX;
       lookRight = !lookRight;      
    }

    //raycast, emite una linea laser para detectar la distancia a los demás objetos.


}
