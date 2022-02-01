using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRB;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        //le damos speed a velocity para que realice el movimiento, en el eje y no varia.
        playerRB.velocity = new Vector2(move * speed, playerRB.velocity.y);



        
    }
}
