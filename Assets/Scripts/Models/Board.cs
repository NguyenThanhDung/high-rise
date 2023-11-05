using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    private BoardSlot[,] boardSlots;
    private ScoreManager scoreManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        this.boardSlots = new BoardSlot[GameManager.Instance.boardSize, GameManager.Instance.boardSize];
    }

    public void OnPuttingPillar()
    {
        Debug.Log("Board.OnPuttingPillar()");
    }
}
