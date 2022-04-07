using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    public GameObject ballGO;
    public Transform objTrans;
    public Transform disparador;
    public Transform h;


    public float gravity = -9.81f;

    IEnumerator Preparando()
    {
        yield return new WaitForSeconds(2f);
        Lanzar();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(ballGO, disparador.position, disparador.rotation);
            StartCoroutine("Preparando");
        }
    }

    void Lanzar()
    {
        Rigidbody ballRB = ballGO.GetComponent<Rigidbody>();
        Debug.Log("balon"+ballRB);
        Physics.gravity = Vector3.up * gravity;
        ballRB.useGravity = true;
        ballRB.velocity = CalcularVelocidadInicial();
        print(ballRB.velocity);

    }
    Vector3 CalcularVelocidadInicial()
    {
        Vector3 desplazamientoP = objTrans.position - disparador.position;

        float velocidadY, velocidadX, velocidadZ;
        velocidadY = Mathf.Sqrt(-2 * gravity * h.position.y);
        velocidadX = desplazamientoP.x / ((-velocidadY / gravity) + (Mathf.Sqrt(2 * (desplazamientoP.y - h.position.y) / gravity)));
        velocidadZ = desplazamientoP.z / ((-velocidadY / gravity) + (Mathf.Sqrt(2 * (desplazamientoP.y - h.position.y) / gravity)));

        return new Vector3(velocidadX, velocidadY, velocidadZ);
    }
}
