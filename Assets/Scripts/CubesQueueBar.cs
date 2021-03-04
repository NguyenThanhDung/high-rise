using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubesQueueBar : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject queuedCubePrefab;
    
    void Start()
    {
        StartCoroutine(ShowCubesQueue());
    }

    private IEnumerator ShowCubesQueue()
    {
        while(this.gameManager.CubesQueue == null)
            yield return null;
        for(int i=0; i<GameManager.MAX_CUBES_QUEUE_SIZE; i++)
        {
            var queuedCube = Instantiate(this.queuedCubePrefab, this.transform);
            var queuedCubeRect = queuedCube.GetComponent<RectTransform>();
            queuedCubeRect.anchoredPosition = new Vector2(120 * i, 20);
            var image = queuedCube.GetComponent<Image>();
            image.color = gameManager.CubesQueue.Peek();
        }
    }
}
