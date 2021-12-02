using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    string[] nombresNinjas = {"Scorpion","Kano","Sonya","Johnny Cage","Sub.Zero"};
    string[] tiposNinjas = { "Ninja", "Mercenario", "Teniente", "Actor", "Ninja" };
    List<GameObject> Deaths = new List<GameObject>();

    GameObject[] gameObjects;
    void Start()
    {
        initFighters();  
        
        Debug.Log("El personaje con mas vida es: " + maxhealth().nombre);

        int azar = Random.Range(0, 4); //personaje al azar que le descontaremos toda la vida para que muera.
        gameObjects[azar].GetComponent<Fighter>().DecreaseHealth(120);

        comprobarMuerte();

        Debug.Log(Deaths.Count);

    }

    // Update is called once per frame
    void Update()
    {

       

    }

    void initFighters() {

        gameObjects = GameObject.FindGameObjectsWithTag("fighter");

        for(int i=0; i<gameObjects.Length; i++)
        {
            Fighter ninja = gameObjects[i].GetComponent<Fighter>();
            ninja.nombre = nombresNinjas[i];
            ninja.category = tiposNinjas[i];
            ninja.healthy = Random.Range(80, 100);
        }

    }

    Fighter maxhealth() {
        int vidaMaxima = 0;
        Fighter maximo=null;
        for (int j = 0; j < gameObjects.Length; j++) {

            if (vidaMaxima < gameObjects[j].GetComponent<Fighter>().healthy) {
                vidaMaxima = gameObjects[j].GetComponent<Fighter>().healthy;
                maximo = gameObjects[j].GetComponent<Fighter>();
            }
        }
        return maximo;
    }

    void comprobarMuerte() {
        for (int k = 0; k <= gameObjects.Length - 1; k++)
        {
            if (gameObjects[k].GetComponent<Fighter>().healthy <= 0)
            {
                Debug.Log("Murio " + gameObjects[k].GetComponent<Fighter>().nombre);
                Deaths.Add(gameObjects[k]);
            }
        }
    }

}
