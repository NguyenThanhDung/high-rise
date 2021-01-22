using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer cubePrefab;

    void Start()
    {
        Instantiate(this.cubePrefab);
    }
}
