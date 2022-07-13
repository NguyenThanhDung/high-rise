using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubesQueueBar : MonoBehaviour
{
    [SerializeField] GameObject queuedCubePrefab;

    void Awake()
    {
        Predictor.OnUpdateCubesQueue += OnUpdateCubesQueue;
    }

    void OnDestroy()
    {
        Predictor.OnUpdateCubesQueue -= OnUpdateCubesQueue;
    }

    private void OnUpdateCubesQueue(Queue<Color> cubesQueue)
    {
        int i = 0;
        foreach(Color cubeColor in cubesQueue)
        {
            var queuedCube = Instantiate(this.queuedCubePrefab, this.transform);
            var queuedCubeRect = queuedCube.GetComponent<RectTransform>();
            queuedCubeRect.anchoredPosition = new Vector2(120 * i++, 20);
            var image = queuedCube.GetComponent<Image>();
            image.color = cubeColor;
        }
    }
}
