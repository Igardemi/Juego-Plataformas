using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    SpriteRenderer myCard;
    public Sprite back;
    public Sprite front;
    public bool faceUp = false;
    public string tipo;
    GameObject controller;

    private void Awake()
    {
        myCard = GetComponent<SpriteRenderer>();
        controller = GameObject.FindGameObjectWithTag("GameController");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        myCard.sprite = back;
       


    }
    private void OnMouseDown()
    {
        controller.GetComponent<GameManager>().ClickOnCard(tipo);
        if (faceUp == false)
        {
            GetComponent<SpriteRenderer>().sprite = front;
            faceUp = true;
            
        }
        else {
            GetComponent<SpriteRenderer>().sprite = back;
            faceUp = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }


}
