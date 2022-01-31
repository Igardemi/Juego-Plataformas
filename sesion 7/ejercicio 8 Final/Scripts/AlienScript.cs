using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{

    bool inGame = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Rocket")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "spaceship") {
            inGame = false;
        }
        
    }

}
