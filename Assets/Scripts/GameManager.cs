﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int MAX_CUBES_QUEUE_SIZE = 3;

    [SerializeField] private GameObject placeholderPrefab;
    [SerializeField] private MeshRenderer cubePrefab;
    [SerializeField] private Material[] materials;
    [SerializeField] private int boardSize;

    private List<Vector2> emptyLocations;

    public Color[] CubesQueue { get; private set; }

    private void Start()
    {
        SpawnPlaceholders();
        InitializeEmptyLocation();
        for(int i = 0; i < materials.Length; i++)
        {
            var location = PopRandomLocation();
            var cube = Instantiate(this.cubePrefab, new Vector3(location.x, 0, location.y), Quaternion.identity);
            var meshRenderer = cube.GetComponent<MeshRenderer>();
            meshRenderer.material = this.materials[i];
        }
        InitializeCubesQueue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast (ray, out hit))
            {
                if(hit.collider.CompareTag("Placeholder"))
                {
                    OnClickPlaceholder(hit.transform.position);
                }
            }
        }
    }

    private void SpawnPlaceholders()
    {
        for(int i = 0; i < this.boardSize; i++)
        {
            for(int j = 0; j < this.boardSize; j++)
            {
                Instantiate(this.placeholderPrefab, new Vector3(i, -0.5f, j), Quaternion.Euler(90, 0, 0));
            }
        }
    }

    private void InitializeEmptyLocation()
    {
        this.emptyLocations = new List<Vector2>();
        for(int i = 0; i < this.boardSize; i++)
        {
            for(int j = 0; j < this.boardSize; j++)
            {
                Vector2 newLocation = new Vector2(i, j);
                this.emptyLocations.Add(newLocation);
            }
        }
    }

    private Vector2 PopRandomLocation()
    {
        int index = Random.Range(0, this.emptyLocations.Count);
        var location = this.emptyLocations[index];
        this.emptyLocations.RemoveAt(index);
        return location;
    }

    private void InitializeCubesQueue()
    {
        this.CubesQueue = new Color[MAX_CUBES_QUEUE_SIZE];
        for(int i = 0; i < MAX_CUBES_QUEUE_SIZE; i++)
        {
            int colorIndex = Random.Range(0, MAX_CUBES_QUEUE_SIZE);
            Color color = (colorIndex == 0) ? Color.red : ((colorIndex == 1) ? Color.green : Color.blue);
            this.CubesQueue[i] = color;
        }
    }

    private void OnClickPlaceholder(Vector3 placeholderPosition)
    {
        var cube = Instantiate(this.cubePrefab, placeholderPosition + Vector3.up * 0.5f, Quaternion.identity);
        var meshRenderer = cube.GetComponent<MeshRenderer>();
        int index = Random.Range(0, this.materials.Length);
        meshRenderer.material = this.materials[index];
    }
}
