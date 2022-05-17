using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CamaraDeSeguimiento : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform[] target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] TMP_Dropdown dropdown;


    private void FixedUpdate()
    {
        ManageVehicle();
    }

    public void ManageVehicle()
    {
        if(dropdown.value == 0)
        {
            HandleTranslation(0);
            HandleRotation(0);
        }
        else if (dropdown.value == 1)
        {
            HandleTranslation(1);
            HandleRotation(1);
        }
        else if (dropdown.value == 2)
        {
            HandleTranslation(2);
            HandleRotation(2);
        }
    }

    private void HandleTranslation(int _vehicle)
    {
        var targetPosition = target[_vehicle].TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    private void HandleRotation(int _vehicle)
    {
        var direction = target[_vehicle].position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
