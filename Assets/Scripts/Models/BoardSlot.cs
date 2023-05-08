using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour
{
    private Pillar pillar;

    public void OnTap()
    {
        Console.WriteLine("Tapping slot");
    }

    public void Combine(BoardSlot other)
    {
        Console.WriteLine("Combining with other pillars");
    }

    public void MergePillars()
    {
        Console.WriteLine("Merging pillars");
    }

    public void Clear()
    {
        Console.WriteLine("Clearing pillar");
    }
}
