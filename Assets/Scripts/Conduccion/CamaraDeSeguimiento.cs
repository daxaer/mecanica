using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDeSeguimiento : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform objetivo;
    [SerializeField] private float velTraslacion;
    [SerializeField] private float velRotacion;

    private void FixedUpdate()
    {
        Traslacion();
        Rotacion();
    }

    private void Traslacion()
    {
        var posObjetivo = objetivo.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, posObjetivo, velTraslacion * Time.deltaTime);
    }

    private void Rotacion()
    {
        var direccion = objetivo.position - transform.position;
        var rotacion = Quaternion.LookRotation(direccion, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, velRotacion * Time.deltaTime);
    }

}
