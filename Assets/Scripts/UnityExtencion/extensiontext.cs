using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extensiontext : MonoBehaviour
{
    public int[] arregloNumeros;
    private void Start()
    {
        int index = arregloNumeros.GetRandomIndex();
        print(arregloNumeros[index]);

        Vector3 pos = transform.position;
        transform.SetPosX(10f);
     
    }



}
