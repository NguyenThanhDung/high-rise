using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Color _color;

    public Color CubeColor { get { return _color; } }

    public void SetColor(Color color)
    {
        _color = color;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = _color;
    }
}
