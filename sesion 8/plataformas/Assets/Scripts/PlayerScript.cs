using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRB;
    float speed = 5;
    float move;
    bool lookRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Movements();        
    }

    private void Movements() {

        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            move = Input.GetAxis("Horizontal");
            //le damos speed a velocity para que realice el movimiento, en el eje y no varia.
            playerRB.velocity = new Vector2(move * speed, playerRB.velocity.y);
            lookRight = true;
        }
        else if (Input.GetAxis("Horizontal") == 0) { 
        //mantiene la posicion.
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            move = Input.GetAxis("Horizontal");
            //le damos speed a velocity para que realice el movimiento, en el eje y no varia.
            playerRB.velocity = new Vector2(move * speed, playerRB.velocity.y);
            lookRight = false;
        }

    }
}
