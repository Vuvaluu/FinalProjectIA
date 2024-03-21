using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulationGenerator : MonoBehaviour
{
    #region Singleton Pattern
        private static PopulationGenerator instance;
        public static PopulationGenerator Instance { 
            get { 
                return instance; 
            } 
        }
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this);
            }
            
        }
    #endregion
    List<GameObject> grassTiles = new List<GameObject>();
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] GameObject apatosaurusPrefab;
    [SerializeField] GameObject stegosaurusPrefab;
    [SerializeField] GameObject trexPrefab;
    [SerializeField] GameObject velociraptorPrefab;
    [SerializeField] TMP_InputField apatosaurusInputField;
    [SerializeField] TMP_InputField stegosaurusInputField;
    [SerializeField] TMP_InputField velociraptorInputField;
    [SerializeField] TMP_InputField trexInputField;
    private int numberOfApatosaurus;
    private int numberOfStegosaurus;
    private int numberOfVelociraptor;
    private int numberOfTrex;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GeneratePopulation()
    {
        numberOfApatosaurus = int.Parse(apatosaurusInputField.text);
        numberOfStegosaurus = int.Parse(stegosaurusInputField.text);
        numberOfVelociraptor = int.Parse(velociraptorInputField.text);
        numberOfTrex = int.Parse(trexInputField.text);

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

    public void SpawnApatosaurus(Vector3 position)
    {
        Instantiate(apatosaurusPrefab, position, Quaternion.identity);
    }

    public void SpawnStegosaurus(Vector3 position)
    {
        Instantiate(stegosaurusPrefab, position, Quaternion.identity);
    }

     public void SpawnVelociraptor(Vector3 position)
    {
        Instantiate(velociraptorPrefab, position, Quaternion.identity);
    }

    public void SpawnTrex(Vector3 position)
    {
        Instantiate(trexPrefab, position, Quaternion.identity);
    }
}
