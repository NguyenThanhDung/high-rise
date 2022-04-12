using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public const int MAX_CUBES_QUEUE_SIZE = 3;

    public int boardSize;
    public Color[] colors;

    [SerializeField] private GameObject placeholderPrefab;

    private Queue<Color> cubesQueue;

    public Action<Color, Vector3> OnPlaceCube;
    public Action<Queue<Color>> OnUpdateCubesQueue;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnPlaceholders();
        InitializeCubesQueue();
        OnUpdateCubesQueue(this.cubesQueue);
    }

    private void SpawnPlaceholders()
    {
        for (int i = 0; i < this.boardSize; i++)
        {
            for (int j = 0; j < this.boardSize; j++)
            {
                Instantiate(this.placeholderPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
            }
        }
    }

    private void InitializeCubesQueue()
    {
        this.cubesQueue = new Queue<Color>();
        for (int i = 0; i < MAX_CUBES_QUEUE_SIZE; i++)
        {
            AddCubeToQueue();
        }
    }

    public void OnClickPlaceholder(Vector3 placeholderPosition)
    {
        Color nextCube = this.cubesQueue.Dequeue();
        AddCubeToQueue();
        OnPlaceCube(nextCube, placeholderPosition);
        OnUpdateCubesQueue(this.cubesQueue);
    }

    private void AddCubeToQueue()
    {
        int colorIndex = UnityEngine.Random.Range(0, MAX_CUBES_QUEUE_SIZE);
        Color color = this.colors[colorIndex];
        this.cubesQueue.Enqueue(color);
    }
}
