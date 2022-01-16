using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public int force;
    Rigidbody2D myRigidBody;
    public GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //capturamos el movimiento de las teclas left y right
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        //traferimos el movimiento a nuestro objeto nave a través de añadir velocidad.
        myRigidBody.velocity = transform.right * movimientoHorizontal * force;

        //Restringimos el valor en x para que la nave no salga de la pantalla
        float xPos = Mathf.Clamp(myRigidBody.position.x, -6.5f, 6.5f);
       
        myRigidBody.position = new Vector2(xPos, transform.position.y);

        //vamos detectar la pulsacion de la tecla disparo.
        if (Input.GetButton("Jump")) {
            //Instanciamos el prefab del misil.
            Vector2 posicionMisil = new Vector2(transform.position.x, transform.position.y + 1.5f);
            GameObject clone = Instantiate(rocket,posicionMisil, Quaternion.identity);

            //le otorgamos fuerza al rocket para su movimiento.
            Rigidbody2D cloneRB= clone.GetComponent<Rigidbody2D>();
            //definimos la direccion de movimiento.
            Vector2 direccion = new Vector2(0f, 1f);
            //añadimos la fuerzaal rocket.
            int fuerzaRocket = 200;
            //añadimos la fuerza para el movimiento.
            cloneRB.AddForce(direccion * fuerzaRocket);
        }
            
    }
}
