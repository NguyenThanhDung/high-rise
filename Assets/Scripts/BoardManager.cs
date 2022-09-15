using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject placeholderPrefab;
    [SerializeField] private MeshRenderer cubePrefab;

    void Awake()
    {
        GameEvents.OnClickingPlaceholder += PlaceCube;
    }


    private void Start()
    {
        SpawnPlaceholders();
    }

    void OnDestroy()
    {
        GameEvents.OnClickingPlaceholder -= PlaceCube;
    }

    private void SpawnPlaceholders()
    {
        for (int i = 0; i < GameManager.Instance.boardSize; i++)
        {
            for (int j = 0; j < GameManager.Instance.boardSize; j++)
            {
                Instantiate(this.placeholderPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
            }
        }
    }

    private void PlaceCube(Vector3 position)
    {
        var cube = Instantiate(this.cubePrefab, position + Vector3.up * 0.5f, Quaternion.identity, this.transform);
        cube.material.color = Predictor.Instance.PopColor();
    }
}
