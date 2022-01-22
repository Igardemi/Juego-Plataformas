using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    bool move = true;
    public int Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.Translate(Vector2.right*Time.deltaTime*Speed);
        }
        else {
            transform.Translate(Vector2.left * Time.deltaTime);

        }
        if (transform.position.x >= 6.8) {
            move = false;
        }
        if (transform.position.x <= -6.8)
        {
            move = true;
        }

    }

}
