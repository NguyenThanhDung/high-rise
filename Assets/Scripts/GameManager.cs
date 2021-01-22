using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer cubePrefab;
    [SerializeField] private Material material;

    void Start()
    {
        var cube = Instantiate(this.cubePrefab);
        var meshRenderer = cube.GetComponent<MeshRenderer>();
        meshRenderer.material = this.material;
    }
}
