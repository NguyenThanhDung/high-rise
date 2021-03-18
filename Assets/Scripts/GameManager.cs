using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int MAX_CUBES_QUEUE_SIZE = 3;

    public int boardSize;
    public Color[] colors;

    [SerializeField] private GameObject placeholderPrefab;
    [SerializeField] private MeshRenderer cubePrefab;

    private Queue<Color> cubesQueue;

    public Action<Queue<Color>> OnUpdateCubesQueue;

    private void Start()
    {
        SpawnPlaceholders();
        InitializeCubesQueue();
        OnUpdateCubesQueue(this.cubesQueue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast (ray, out hit))
            {
                if(hit.collider.CompareTag("Placeholder"))
                {
                    OnClickPlaceholder(hit.transform.position);
                }
            }
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

    private void InitializeCubesQueue()
    {
        this.cubesQueue = new Queue<Color>();
        for(int i = 0; i < MAX_CUBES_QUEUE_SIZE; i++)
        {
            AddCubeToQueue();
        }
    }

    private void OnClickPlaceholder(Vector3 placeholderPosition)
    {
        Color nextCube = this.cubesQueue.Dequeue();
        AddCubeToQueue();
        PlaceCube(nextCube, placeholderPosition);
        OnUpdateCubesQueue(this.cubesQueue);
    }

    private void AddCubeToQueue()
    {
        int colorIndex = UnityEngine.Random.Range(0, MAX_CUBES_QUEUE_SIZE);
        Color color = this.colors[colorIndex];
        this.cubesQueue.Enqueue(color);
    }

    private void PlaceCube(Color cubeColor, Vector3 position)
    {
        var cube = Instantiate(this.cubePrefab, position + Vector3.up * 0.5f, Quaternion.identity);
        var meshRenderer = cube.GetComponent<MeshRenderer>();
        meshRenderer.material.color = cubeColor;
    }
}
