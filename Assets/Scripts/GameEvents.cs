using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action<Vector3> OnPlacingCube;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast (ray, out hit))
            {
                if(hit.collider.CompareTag("Placeholder"))
                {
                    OnPlacingCube(hit.transform.position);
                }
            }
        }
    }
}
