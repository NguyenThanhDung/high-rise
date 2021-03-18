using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStackManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private MeshRenderer cubePrefab;

    private void Start()
    {
        SpawnFirstCubes();
    }

    private void SpawnFirstCubes()
    {
        List<Vector2> emptyLocations = GenerateLocations();
        for(int i = 0; i < this.gameManager.colors.Length; i++)
        {
            var location = PopRandomLocation(emptyLocations);
            var cube = Instantiate(this.cubePrefab, new Vector3(location.x, 0, location.y), Quaternion.identity, this.transform);
            var meshRenderer = cube.GetComponent<MeshRenderer>();
            meshRenderer.material.color = this.gameManager.colors[i];
        }
    }

    private List<Vector2> GenerateLocations()
    {
        List<Vector2> emptyLocations = new List<Vector2>();
        for (int i = 0; i < this.gameManager.boardSize; i++)
        {
            for (int j = 0; j < this.gameManager.boardSize; j++)
            {
                Vector2 newLocation = new Vector2(i, j);
                emptyLocations.Add(newLocation);
            }
        }
        return emptyLocations;
    }

    private Vector2 PopRandomLocation(List<Vector2> emptyLocations)
    {
        int index = UnityEngine.Random.Range(0, emptyLocations.Count);
        var location = emptyLocations[index];
        emptyLocations.RemoveAt(index);
        return location;
    }
}
