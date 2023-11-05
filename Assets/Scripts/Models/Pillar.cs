using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    private Cube cubePrefab;

    private List<Cube> _cubes;

    void Awake()
    {
        _cubes = new List<Cube>();
    }

    void Start()
    {
        var cube = Instantiate(this.cubePrefab, this.transform.position + Vector3.up * 0.5f, Quaternion.identity, this.transform);
    }
}
