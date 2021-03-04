using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubesQueueBar : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject queuedCubePrefab;

    void Awake()
    {
        gameManager.OnUpdateCubesQueue += OnUpdateCubesQueue;
    }

    void OnDestroy()
    {
        gameManager.OnUpdateCubesQueue -= OnUpdateCubesQueue;
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
