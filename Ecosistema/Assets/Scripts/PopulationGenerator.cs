using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationGenerator : MonoBehaviour
{
    List<GameObject> grassTiles = new List<GameObject>();
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] GameObject apatosaurusPrefab;
    [SerializeField] GameObject stegosaurusPrefab;
    [SerializeField] GameObject trexPrefab;
    [SerializeField] GameObject velociraptorPrefab;

    private int numberOfApatosaurus = 10;
    private int numberOfStegosaurus = 10;
    private int numberOfTrex = 10;
    private int numberOfVelociraptor = 10;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void GeneratePopulation()
    {
        foreach (GameObject tile in levelGenerator.GetCells())
        {
            if(tile != null && tile.tag == "Pasto")
            {
                grassTiles.Add(tile);
            }
        }
        SpawnDinosaurs(numberOfApatosaurus, apatosaurusPrefab, new Vector3(0, 0.566f, 0));
        SpawnDinosaurs(numberOfStegosaurus, stegosaurusPrefab, new Vector3(0, 0.566f, 0));
        SpawnDinosaurs(numberOfTrex, trexPrefab, new Vector3(0, 0.566f, 0));
        SpawnDinosaurs(numberOfVelociraptor, velociraptorPrefab, new Vector3(0, 0.566f, 0));
       
    }

    public void SpawnDinosaurs(int numberOfDinosaurs, GameObject dinosaurPrefab, Vector3 spawnOffset)
    {
         List<GameObject> spawnTiles = new List<GameObject>();
        for (int i = 0; i < numberOfDinosaurs; i++)
        {
            spawnTiles.Add(grassTiles[Random.Range(0, grassTiles.Count)]);
        }

        foreach (GameObject tile in spawnTiles)
        {
            Instantiate(dinosaurPrefab, tile.transform.position + spawnOffset, Quaternion.identity);
        }
    }
}
