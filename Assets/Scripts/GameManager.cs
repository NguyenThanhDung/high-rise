using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject placeholderPrefab;
    [SerializeField] private MeshRenderer cubePrefab;
    [SerializeField] private Material[] materials;
    [SerializeField] private int boardSize;

    private List<Vector2> emptyLocations;

    private void Start()
    {
        SpawnPlaceholders();
        InitializeEmptyLocation();
        for(int i = 0; i < materials.Length; i++)
        {
            var location = PopRandomLocation();
            var cube = Instantiate(this.cubePrefab, new Vector3(location.x, 0, location.y), Quaternion.identity);
            var meshRenderer = cube.GetComponent<MeshRenderer>();
            meshRenderer.material = this.materials[i];
        }
    }

    private void SpawnPlaceholders()
    {
        for(int i = 0; i < this.boardSize; i++)
        {
            for(int j = 0; j < this.boardSize; j++)
            {
                Instantiate(this.placeholderPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
            }
        }
    }

    private void InitializeEmptyLocation()
    {
        this.emptyLocations = new List<Vector2>();
        for(int i = 0; i < this.boardSize; i++)
        {
            for(int j = 0; j < this.boardSize; j++)
            {
                Vector2 newLocation = new Vector2(i, j);
                this.emptyLocations.Add(newLocation);
            }
        }
    }

    private Vector2 PopRandomLocation()
    {
        int index = Random.Range(0, this.emptyLocations.Count);
        var location = this.emptyLocations[index];
        this.emptyLocations.RemoveAt(index);
        return location;
    }
}
