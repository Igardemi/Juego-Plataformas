using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string nombre;
    public string category;
    public int healthy;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    public void DecreaseHealth(int cantidad){

        healthy -= cantidad;
    }

    void isAlive() {
        if (healthy <= 0) {
            Debug.Log("El personaje esta muerto.");
        }
        Debug.Log("El personaje esta vivo.");
    }
}
