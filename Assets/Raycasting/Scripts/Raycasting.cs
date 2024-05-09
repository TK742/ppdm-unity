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
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), ))
        {
            
        }
    }
}
