using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public int force;
    Rigidbody2D myRigidBody;
    public GameObject rocket;
    public bool shoot = true;
    bool inGame = true;
    GameObject gameOver;
    GameObject textWin;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("Finish");
        myRigidBody = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        textWin = GameObject.FindGameObjectWithTag("Bonus");
        textWin.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inGame)
        {
            //capturamos el movimiento de las teclas left y right
            float movimientoHorizontal = Input.GetAxis("Horizontal");

            //traferimos el movimiento a nuestro objeto nave a través de añadir velocidad.
            myRigidBody.velocity = transform.right * movimientoHorizontal * force;

            //Restringimos el valor en x para que la nave no salga de la pantalla
            float xPos = Mathf.Clamp(myRigidBody.position.x, -6.5f, 6.5f);

            myRigidBody.position = new Vector2(xPos, transform.position.y);

            if (Input.GetButton("Jump") && shoot == true)//capturamos el pulsado de la tecla espacio.
            {
                ShootSystem();

            }
        }

    }
        private void ShootSystem()
        {

                //Instanciamos el prefab del misil.
                Vector2 posicionMisil = new Vector2(transform.position.x, transform.position.y + 1.8f);
                GameObject clone = Instantiate(rocket, posicionMisil, Quaternion.identity);

                //le otorgamos fuerza al rocket para su movimiento.
                Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();
                //definimos la direccion de movimiento.
                Vector2 direccion = new Vector2(0f, 1f);
                //añadimos la fuerzaal rocket.
                int fuerzaRocket = 20;
                //añadimos la fuerza para el movimiento.
                cloneRB.velocity = direccion * fuerzaRocket;
                shoot = false;

        }

    public void setShoot() {
        shoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            theEnd();
            gameOver.SetActive(true);
        }

    }

    public void theEnd() {
        inGame = false;
        textWin.SetActive(true);
    }

}
