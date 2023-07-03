using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardSlot[,] boardSlots;
    private ScoreManager scoreManager;

    void Awake()
    {
        GameEvents.OnClickingBoardSlot += OnPutPillar;
    }

    void Start()
    {
        this.boardSlots = new BoardSlot[GameManager.Instance.boardSize, GameManager.Instance.boardSize];
    }

    void OnDestroy()
    {
        GameEvents.OnClickingBoardSlot -= OnPutPillar;
    }

    private void OnPutPillar(BoardSlot boardSlot)
    {
        Debug.Log("Putting pillar");
    }
}
