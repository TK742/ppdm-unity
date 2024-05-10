using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layer;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && // Si se detecta el click del mouse
            Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            // Castear un rayo hacia la posición del map. Si hay colisión, ingresa al condicional.
        {
            Debug.Log($"{hit.point} es la posición del hit");
            cube.position = hit.point;
        }
    }
}
