﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //añadimos el Prefab al Game Manager, los frontales y las propiedad de cada carta en las siguientes variables.
    public GameObject myPrefab;
    public List<Sprite> frontales = new List<Sprite>();
    string[] tipoCarta = { "Queen", "Guard","Assassin", "Bishop","Constable"};
    public List<GameObject> listaCartas = new List<GameObject>();
   
    int[] contador = { 0, 0, 0, 0, 0}; //Array creado para llevar el sumatorio en la creacion de cada carta.

    bool estado = true; //Estado sin cartas volteadas.
    string tipoUp = null; //Tipo de la carta levantada que guardamos para comparar con la siguiente.
    int indexPrev = 0; //para guardar la carta levantada que levantamos primero y debemos guardar para comparar con la siguiente.

   

    private void Awake()
    {
        //Creación y posicionamiento de las 10 Cartas.
        float posX = -8;
        float posY = 3;

        GameObject nueva_Carta;
        int nombreId = 0;//creamos la variable para dar nombre diferente a cada carta nueva que creamos.

        for (int i = 0; i < 10; i++)
        { 
            nueva_Carta = Instantiate(myPrefab, new Vector3(posX, posY, 0), Quaternion.identity); //Instanciamos un prefab.
            nueva_Carta.name = ("Carta" + nombreId); // le modificamos el nombre
            nombreId += 1;
            bool encontrado = false;
            int random = 0;

            while (!encontrado)
            {
                random = Random.Range(0, frontales.Count);
                if (contador[random] < 2)
                {


                    contador[random] += 1;
                    encontrado = true;
                }
            }

            nueva_Carta.GetComponent<CardScript>().front = frontales[random]; //le añadimos el frontal
            nueva_Carta.GetComponent<CardScript>().tipo = tipoCarta[random]; //añadimos el tipo de carta
            nueva_Carta.GetComponent<CardScript>().index = i; //añadimos la posicion de la Lista.
            listaCartas.Add(nueva_Carta);

            posX += 2;
            if (i == 4)
            {
                posX = -8;
                posY = -2;
            }

            Debug.Log("hemos creado una carta.");

        }
    }

    
    void Start()
    {

        
    
        //Seguimos el juego.
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnCard(string tipo, int index) {
        
        Debug.Log("Se ha clickado en una carta de:" + tipo);

        if (estado == true) //Estado sin cartas volteadas.
        {
            tipoUp = tipo;
            estado = false;
            indexPrev = index;
        }
        else { //Estado con una carta volteada con la que comparar el tipo de ambas.

            if (tipoUp == tipo)
            {
                Debug.Log("Se ha encontrado la pareja de:" + tipo);
                //Desactivamos las cartas que han hecho pareja
                listaCartas[index].SetActive(false);
                listaCartas[indexPrev].SetActive(false);
            }
            else {

                Debug.Log("No se ha encontrado su pareja.");
                //Volteamos ambas cartas para volver a buscar dos cartas nuevas.
                listaCartas[indexPrev].GetComponent<CardScript>().Toggle();
                listaCartas[index].GetComponent<CardScript>().Toggle();
            }

            estado = true;
        }
    
    }
}