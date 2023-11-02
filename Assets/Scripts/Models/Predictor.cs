using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictor : MonoBehaviour
{
    public static Predictor Instance;

    private Queue<WaitingPillar> _waitingPillars;
    [SerializeField]
    private PredictorBar _predictorBar;

    public static Action<Color, Vector3> OnPlacingCube;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeWaitingPillars();
        _predictorBar.Refresh(this._waitingPillars);
    }

    private void InitializeWaitingPillars()
    {
        _waitingPillars = new Queue<WaitingPillar>();
        for (int i = 0; i < GameManager.MAX_CUBES_QUEUE_SIZE; i++)
        {
            GenerateNewWaitingPillar();
        }
    }

    private void GenerateNewWaitingPillar()
    {
        WaitingPillar waitingPillar = new WaitingPillar();
        _waitingPillars.Enqueue(waitingPillar);
    }

    public WaitingPillar PopWaitingPillar()
    {
        var waitingPillar = _waitingPillars.Dequeue();
        GenerateNewWaitingPillar();
        _predictorBar.Refresh(this._waitingPillars);
        return waitingPillar;
    }
}
