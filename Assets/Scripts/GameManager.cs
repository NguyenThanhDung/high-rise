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

    private void Awake()
    {
        Instance = this;
    }
}
