using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PredictorBar : MonoBehaviour
{
    [SerializeField] GameObject _waitingCubePrefab;

    public void Refresh(Queue<Color> cubesQueue)
    {
        int i = 0;
        foreach(Color cubeColor in cubesQueue)
        {
            var queuedCube = Instantiate(_waitingCubePrefab, this.transform);
            var queuedCubeRect = queuedCube.GetComponent<RectTransform>();
            queuedCubeRect.anchoredPosition = new Vector2(120 * i++, 20);
            var image = queuedCube.GetComponent<Image>();
            image.color = cubeColor;
        }
    }
}
