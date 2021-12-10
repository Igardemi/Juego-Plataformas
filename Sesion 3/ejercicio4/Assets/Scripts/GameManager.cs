using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject myPrefab;
    public List<Sprite> frontales = new List<Sprite>();
    public List<Sprite> frontalElegido = new List<Sprite>();



    private void Awake()
    {
        //creamos una lista con un total 10 frontales, hay 5 variedad de frontales, y cada uno esta repetido dos veces.
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, frontales.Count);
            for (int j = 0; j < 2; j++)
            {
                frontalElegido.Add(frontales[random]);
               
            }
            frontales.RemoveAt(random);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        float posX = -8;
        float posY = 3;

             

        for (int i = 0; i < 10; i++)
        {
            int random2 = Random.Range(0, frontalElegido.Count);
            GameObject nueva_Carta = Instantiate(myPrefab, new Vector3(posX, posY, 0), Quaternion.identity); //Instanciamos un prefab.
            nueva_Carta.name = ("Carta" + i); // le modificamos el nombre
            nueva_Carta.GetComponent<CardScript>().front = frontalElegido[random2]; //le añadimos el frontal
            posX += 3;
            if (i == 4)
            {
                posX = -8;
                posY = -2;
            }

            frontalElegido.RemoveAt(random2); //Eliminamos el frontal de la lista para que no se repita.
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
