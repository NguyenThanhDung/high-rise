using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStackManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer cubePrefab;

    private void Awake()
    {
        Predictor.OnPlacingCube += PlaceCube;
    }

    private void Start()
    {
        SpawnFirstCubes();
    }

    void OnDestroy()
    {
        Predictor.OnPlacingCube -= PlaceCube;
    }

    private void SpawnFirstCubes()
    {
        List<Vector2> emptyLocations = GenerateLocations();
        for(int i = 0; i < GameManager.Instance.colors.Length; i++)
        {
            var location = PopRandomLocation(emptyLocations);
            var cube = Instantiate(this.cubePrefab, new Vector3(location.x, 0, location.y), Quaternion.identity, this.transform);
            cube.material.color = GameManager.Instance.colors[i];
        }
    }

    private List<Vector2> GenerateLocations()
    {
        List<Vector2> emptyLocations = new List<Vector2>();
        for (int i = 0; i < GameManager.Instance.boardSize; i++)
        {
            for (int j = 0; j < GameManager.Instance.boardSize; j++)
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

    private void PlaceCube(Color cubeColor, Vector3 position)
    {
        var cube = Instantiate(this.cubePrefab, position + Vector3.up * 0.5f, Quaternion.identity, this.transform);
        cube.material.color = cubeColor;
    }
}
