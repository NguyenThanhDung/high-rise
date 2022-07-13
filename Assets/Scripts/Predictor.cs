using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictor : MonoBehaviour
{
    private Queue<Color> cubesQueue;

    public static Action<Color, Vector3> OnPlacingCube;
    public static Action<Queue<Color>> OnUpdateCubesQueue;

    void Awake()
    {
        GameEvents.OnClickingPlaceholder += OnClickingPlaceholder;
    }

    void Start()
    {
        InitializeCubesQueue();
        OnUpdateCubesQueue(this.cubesQueue);
    }

    void OnDestroy()
    {
        GameEvents.OnClickingPlaceholder -= OnClickingPlaceholder;
    }

    private void InitializeCubesQueue()
    {
        this.cubesQueue = new Queue<Color>();
        for (int i = 0; i < GameManager.MAX_CUBES_QUEUE_SIZE; i++)
        {
            AddCubeToQueue();
        }
    }

    private void AddCubeToQueue()
    {
        int colorIndex = UnityEngine.Random.Range(0, GameManager.MAX_CUBES_QUEUE_SIZE);
        Color color = GameManager.Instance.colors[colorIndex];
        this.cubesQueue.Enqueue(color);
    }

    public void OnClickingPlaceholder(Vector3 placeholderPosition)
    {
        Color nextCube = this.cubesQueue.Dequeue();
        AddCubeToQueue();
        OnPlacingCube(nextCube, placeholderPosition);
        OnUpdateCubesQueue(this.cubesQueue);
    }
}
