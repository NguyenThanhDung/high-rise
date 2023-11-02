using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Predictor.Instance.PopColor();
    }
}
