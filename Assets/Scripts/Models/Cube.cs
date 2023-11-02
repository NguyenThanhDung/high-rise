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
        var waitingPillar = Predictor.Instance.PopWaitingPillar();
        meshRenderer.material.color = waitingPillar.Colors[0];
    }
}
