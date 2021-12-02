using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public Sprite imagen;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = imagen;
            transform.position = new Vector3(-1, 0, 0);

    }

// Update is called once per frame
void Update()
    {
        
    }
}
