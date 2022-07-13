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


    private Queue<Color> cubesQueue;

    public Action<Color, Vector3> OnPlaceCube;
    public Action<Queue<Color>> OnUpdateCubesQueue;

    private void Awake()
    {
        Instance = this;
        GameEvents.OnPlacingCube += OnPlacingCube;
    }

    private void Start()
    {
        InitializeCubesQueue();
        OnUpdateCubesQueue(this.cubesQueue);
    }

    private void OnDestroy()
    {
        GameEvents.OnPlacingCube -= OnPlacingCube;
    }

    private void InitializeCubesQueue()
    {
        this.cubesQueue = new Queue<Color>();
        for (int i = 0; i < MAX_CUBES_QUEUE_SIZE; i++)
        {
            AddCubeToQueue();
        }
    }

    public void OnPlacingCube(Vector3 placeholderPosition)
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
