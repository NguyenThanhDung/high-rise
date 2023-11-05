using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    [SerializeField]
    private GameObject boardSlotPrefab;

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

        for (int i = 0; i < GameManager.Instance.boardSize; i++)
        {
            for (int j = 0; j < GameManager.Instance.boardSize; j++)
            {
                var boardSlotObj = Instantiate(this.boardSlotPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
                var boardSlot = boardSlotObj.GetComponent<BoardSlot>();
                boardSlot.SetLocation(i, j);
            }
        }
    }

    public void OnPuttingPillar(BoardSlot boardSlot)
    {
        Debug.Log($"Board.OnPuttingPillar() location:({boardSlot.Row}, {boardSlot.Column})");
    }
}
