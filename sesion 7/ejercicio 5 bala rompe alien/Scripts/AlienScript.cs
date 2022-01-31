using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    bool move = true;
    float speed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(speed);
        MoveEnemy();
        StartCoroutine(Wait());
    }

    private void MoveEnemy() {

        if (move == true)
        {
            //transform.Translate(Vector2.right);
            if (transform.position.x > 6)
            {
                move = false;
                speed = speed - 0.1f;
                transform.Translate(Vector2.down);
            }
            else
            {
                transform.Translate(Vector2.right);
            }


        }
        else
        {
            //transform.Translate(Vector2.left);
            if (transform.position.x < -6)
            {
                move = true;
                speed = speed - 0.1f;
                transform.Translate(Vector2.down);
                
            }
            else
            {
                transform.Translate(Vector2.left);
            }

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Rocket")
        {
            Destroy(gameObject);
        }
        
    }

}
