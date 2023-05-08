using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private List<Cube> cubes;

    void Awake()
    {
        this.cubes = new List<Cube>();
    }
}
