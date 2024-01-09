using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("BoardSlot"))
                {
                    BoardSlot boardSlot = hit.transform.gameObject.GetComponent<BoardSlot>();
                    boardSlot.OnTap();
                }
            }
        }
    }
}
