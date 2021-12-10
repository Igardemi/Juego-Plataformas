using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject myPrefab;
    public List<Sprite> frontales = new List<Sprite>();
    string[] tipoCarta = { "Queen", "Guard","Assassin", "Bishop","Constable"};
    public List<GameObject> listaCartas = new List<GameObject>();
    int cantidad = 0;
    int[] contador = { 0, 0, 0, 0, 0};

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        float posX = -8;
        float posY = 3;

        GameObject nueva_Carta;

        for (int i = 0; i < 10; i++)
        {
                      
            nueva_Carta = Instantiate(myPrefab, new Vector3(posX, posY, 0), Quaternion.identity); //Instanciamos un prefab.
            nueva_Carta.name = ("Carta" + cantidad); // le modificamos el nombre
            cantidad += 1;
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
                nueva_Carta.GetComponent<CardScript>().tipo = tipoCarta[random];

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnCard() {
        Debug.Log("Se ha clickado una carta.");
    }
}
