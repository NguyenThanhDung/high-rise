using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    [SerializeField]
    private Pillar pillarPrefab;

    public void OnTap()
    {
        Debug.Log("Tapping slot");
        Instantiate(pillarPrefab, this.transform);
        Board.Instance.OnPuttingPillar();
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
