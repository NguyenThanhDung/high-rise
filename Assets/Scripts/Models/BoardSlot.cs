using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    [SerializeField]
    private Pillar _pillarPrefab;

    private int[] _localtion;

    public int Row { get { return _localtion[0]; } }
    public int Column { get { return _localtion[1]; } }

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
        Instantiate(_pillarPrefab, this.transform);
    }

    public void OnTap()
    {
        Debug.Log("Tapping slot");
        Instantiate(_pillarPrefab, this.transform);
        Board.Instance.OnPuttingPillar(this);
    }

    public void Combine(BoardSlot other)
    {
        Debug.Log("Combining with other pillars");
    }

    public void MergePillars()
    {
        Debug.Log("Merging pillars");
    }

    public void Clear()
    {
        Debug.Log("Clearing pillar");
    }
}
