using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictingPillar : MonoBehaviour
{
    private List<PredictingCube> cubes;

    void Awake()
    {
        this.cubes = new List<PredictingCube>();
    }
}
