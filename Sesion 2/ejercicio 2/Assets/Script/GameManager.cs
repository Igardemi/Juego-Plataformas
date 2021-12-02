using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject myPrefab;
    List<GameObject> cardList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        float posX = -8;
        float posY = 3;

        for (int i = 0; i < 10; i++) { 
        GameObject nueva_Carta = Instantiate(myPrefab, new Vector3(posX, posY,0), Quaternion.identity); //Instanciamos un prefab.
        nueva_Carta.name = ("Carta"+i);

            posX += 3;
            if (i == 4)
            {
                posX = -8;
                posY = -2;
            }

            cardList.Add(nueva_Carta);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
