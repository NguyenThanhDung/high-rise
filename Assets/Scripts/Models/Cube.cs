using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Color _color;

    public Color CubeColor { get { return _color; } }

    void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var waitingPillar = Predictor.Instance.PopWaitingPillar();
        _color = waitingPillar.Colors[0];
        meshRenderer.material.color = _color;
    }
}
