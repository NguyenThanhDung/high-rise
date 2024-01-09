using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private bool _isEnable;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        _isEnable = true;
    }

    private void Update()
    {
        if (_isEnable && Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("BoardSlot"))
                {
                    BoardSlot boardSlot = hit.transform.gameObject.GetComponent<BoardSlot>();
                    boardSlot.OnTap();
                    _isEnable = false;
                }
            }
        }
    }

    public void Enable()
    {
        _isEnable = true;
    }

    public void Disable()
    {
        _isEnable = false;
    }
}
