using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    GameObject spaceShip;
    SpaceshipScript scripShip;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("spaceship");
        scripShip = spaceShip.GetComponent<SpaceshipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scripShip.setShoot();
        Destroy(gameObject);
    }
}
