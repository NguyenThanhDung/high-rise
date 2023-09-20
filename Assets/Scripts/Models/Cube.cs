using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool shouldSetColor = false;

    public bool ShouldSetColor
    {
        get
        {
            return this.shouldSetColor;
        }
        set
        {
            this.shouldSetColor = value;
        }
    }

    void Start()
    {
        if (ShouldSetColor)
        {
            StartCoroutine(SetColor());
        }
    }

    private IEnumerator SetColor()
    {
        yield return 0;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Predictor.Instance.PopColor();
    }
}
