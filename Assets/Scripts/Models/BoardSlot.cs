using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    private Pillar pillar;

    public void OnTap()
    {
        Debug.Log("Tapping slot");
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
