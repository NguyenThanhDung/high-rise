using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingPillar
{
    private List<Color> _colors;

    public List<Color> Colors { get => _colors; private set => _colors = value; }

    public WaitingPillar(Color color)
    {
        Colors = new List<Color>();
        Colors.Add(color);
    }
}
