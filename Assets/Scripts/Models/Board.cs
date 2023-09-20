using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardSlot[,] boardSlots;
    private ScoreManager scoreManager;

    void Start()
    {
        this.boardSlots = new BoardSlot[GameManager.Instance.boardSize, GameManager.Instance.boardSize];
    }
}
