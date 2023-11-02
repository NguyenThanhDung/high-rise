using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingPillar
{
    private List<Color> _colors;

    public List<Color> Colors { get => _colors; private set => _colors = value; }

    public WaitingPillar()
    {
        Colors = new List<Color>();
        GenerateColor();
    }

    private void GenerateColor()
    {
        int colorIndex = Random.Range(0, GameManager.MAX_CUBES_QUEUE_SIZE);
        Color color = GameManager.Instance.colors[colorIndex];
        Colors.Add(color);
    }
}
