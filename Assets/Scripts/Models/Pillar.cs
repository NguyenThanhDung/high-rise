using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    private Cube cubePrefab;

    private List<Cube> _cubes;

    public Color BottomColor
    {
        get
        {
            if (_cubes.Count > 0)
                return _cubes[0].CubeColor;
            return Color.white;
        }
    }

    void Awake()
    {
        _cubes = new List<Cube>();
    }

    void Start()
    {
        var cube = Instantiate(this.cubePrefab, this.transform.position + Vector3.up * 0.5f, Quaternion.identity, this.transform);
        _cubes.Add(cube);
    }
}
