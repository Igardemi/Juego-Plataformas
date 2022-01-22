using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    public float Speed;
    Vector2 bgPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveBg();
    }
    void moveBg() {
        bgPos = new Vector2(0, Time.time * Speed);
        GetComponent<Renderer>().material.mainTextureOffset = bgPos;
    }
}
