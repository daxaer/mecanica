using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform spawn;
    [SerializeField] private float velocidadBala = 1500;
    [SerializeField] private float velocidadDisparo = 0.5f;

    [SerializeField] private float ratioDeDisparo = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > ratioDeDisparo)
            {
                GameObject nuevaBala;
                nuevaBala = Instantiate(bala,spawn.position,spawn.rotation);

                nuevaBala.GetComponent<Rigidbody>().AddForce(spawn.forward*velocidadBala);

                ratioDeDisparo = Time.time + velocidadDisparo;
                Destroy(nuevaBala, 2f);
            }
        }
    }
}
