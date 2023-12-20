using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    [SerializeField]
    private GameObject boardSlotPrefab;

    private BoardSlot[,] _boardSlots;
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
        InitializeBoardSlots();
        SpawnFirstPillars();
    }

    private void InitializeBoardSlots()
    {
        _boardSlots = new BoardSlot[GameManager.Instance.boardSize, GameManager.Instance.boardSize];
        for (int i = 0; i < GameManager.Instance.boardSize; i++)
        {
            for (int j = 0; j < GameManager.Instance.boardSize; j++)
            {
                var boardSlotObj = Instantiate(this.boardSlotPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
                var boardSlot = boardSlotObj.GetComponent<BoardSlot>();
                boardSlot.SetLocation(i, j);
                _boardSlots[i, j] = boardSlot;
            }
        }
    }

    private void SpawnFirstPillars()
    {
        List<int[]> emptyLocations = GenerateLocations();
        for (int i = 0; i < 3; i++)
        {
            var location = PopRandomLocation(emptyLocations);
            var boardSlot = _boardSlots[location[0], location[1]];
            boardSlot.GenerateFirstPillar();
        }
    }

    private List<int[]> GenerateLocations()
    {
        List<int[]> emptyLocations = new List<int[]>();
        for (int i = 0; i < GameManager.Instance.boardSize; i++)
        {
            for (int j = 0; j < GameManager.Instance.boardSize; j++)
            {
                int[] location = new int[] { i, j };
                emptyLocations.Add(location);
            }
        }
        return emptyLocations;
    }

    private int[] PopRandomLocation(List<int[]> emptyLocations)
    {
        int index = Random.Range(0, emptyLocations.Count);
        var location = emptyLocations[index];
        emptyLocations.RemoveAt(index);
        return location;
    }

    private List<BoardSlot> GetNeighbors(BoardSlot currentBoardSlot)
    {
        int row = currentBoardSlot.Row;
        int col = currentBoardSlot.Column;
        List<BoardSlot> neighbors = new List<BoardSlot>();
        if (currentBoardSlot.Row > 0)
            neighbors.Add(_boardSlots[row - 1, col]);
        if (currentBoardSlot.Row < _boardSlots.GetLength(0) - 1)
            neighbors.Add(_boardSlots[row + 1, col]);
        if (currentBoardSlot.Column > 0)
            neighbors.Add(_boardSlots[row, col - 1]);
        if (currentBoardSlot.Column < _boardSlots.GetLength(1) - 1)
            neighbors.Add(_boardSlots[row, col + 1]);
        return neighbors;
    }

    private IEnumerator Merge(BoardSlot currentBoardSlot)
    {
        yield return null;
        Debug.Log($"Board.OnPuttingPillar() location:({currentBoardSlot.Row}, {currentBoardSlot.Column})");
        List<BoardSlot> neighbors = GetNeighbors(currentBoardSlot);

        List<BoardSlot> mergableNeighbors = new List<BoardSlot>();
        foreach (var neighbor in neighbors)
        {
            if (neighbor.HasPillar)
            {
                if (currentBoardSlot.Pillar.BottomColor == neighbor.Pillar.BottomColor
                    && currentBoardSlot.Pillar.Height == neighbor.Pillar.Height)
                {
                    mergableNeighbors.Add(neighbor);
                }
            }
        }

        if (mergableNeighbors.Count == 1)
        {
            mergableNeighbors[0].Consume(currentBoardSlot);
        }
        else if (mergableNeighbors.Count > 1)
        {
            currentBoardSlot.Consume(mergableNeighbors);
        }
    }

    public void OnPuttingPillar(BoardSlot boardSlot)
    {
        StartCoroutine(Merge(boardSlot));
    }
}
