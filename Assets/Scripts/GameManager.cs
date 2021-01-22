using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer cubePrefab;
    [SerializeField] private Material[] materials;

    void Start()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            var cube = Instantiate(this.cubePrefab, Vector3.right * i, Quaternion.identity);
            var meshRenderer = cube.GetComponent<MeshRenderer>();
            meshRenderer.material = this.materials[i];
        }
    }
}
