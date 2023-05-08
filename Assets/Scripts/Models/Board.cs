using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardSlot[,] boardSlots;
    private ScoreManager scoreManager;

    void Awake()
    {
        this.boardSlots = new BoardSlot[GameManager.Instance.boardSize, GameManager.Instance.boardSize];
    }

    private void OnPutPillar()
    {
        Console.WriteLine("Putting pillar");
    }
}
