using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMira : MonoBehaviour
{
    public float SensibilidadM = 100f;
    public Transform cuerpoPersonaje;
    float rotacionL = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * SensibilidadM * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * SensibilidadM * Time.deltaTime;

        rotacionL -= mouseY;
        rotacionL = Mathf.Clamp(rotacionL, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionL, 0f, 0f);
        cuerpoPersonaje.Rotate(Vector3.up * mouseX);
    }
}
