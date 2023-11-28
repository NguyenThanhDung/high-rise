using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    [SerializeField]
    private Pillar _pillarPrefab;

    private int[] _localtion;
    private Pillar _pillar;

    public int Row { get { return _localtion[0]; } }
    public int Column { get { return _localtion[1]; } }
    public bool HasPillar { get { return _pillar != null; } }
    public Pillar Pillar { get { return _pillar; } }

    void Awake()
    {
        _localtion = new int[2];
    }

    public void SetLocation(int row, int col)
    {
        _localtion[0] = row;
        _localtion[1] = col;
    }

    public void GenerateFirstPillar()
    {
        _pillar = Instantiate(_pillarPrefab, this.transform);
    }

    public void OnTap()
    {
        Debug.Log("Tapping slot");
        _pillar = Instantiate(_pillarPrefab, this.transform);
        Board.Instance.OnPuttingPillar(this);
    }

    public void Consume(BoardSlot other)
    {
        Debug.Log($"Consume pillar ({other.Row},{other.Column})");
    }

    public void Consume(List<BoardSlot> others)
    {
        String log = "Consume pillars: ";
        foreach (var boardSlot in others)
            log += "(" + boardSlot.Row + "," + boardSlot.Column + ")";
        Debug.Log(log);
    }

    public void Clear()
    {
        Debug.Log("Clearing pillar");
    }
}
