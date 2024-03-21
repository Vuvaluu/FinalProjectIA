using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    #region Singleton Pattern
        private static LevelGenerator instance;
        public static LevelGenerator Instance { 
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
    [SerializeField] int rows;
    [SerializeField] int cols;
    [SerializeField] int ite;
    [SerializeField] GameObject blankCell;
    [SerializeField] GameObject fullCell;
    [SerializeField] Button generateButton;
    [SerializeField] TMP_InputField sizeX_IF;
    [SerializeField] TMP_InputField sizeY_IF;
    [SerializeField] TMP_InputField iteNumber_IF;
    [SerializeField] Toggle steppedToggle;

    [SerializeField] GameObject treePrefab1;
    [SerializeField] GameObject treePrefab2;
    public List<GameObject> oldCells = new List<GameObject>();
    public List<GameObject> grassTiles = new List<GameObject>();
    public List<GameObject> treeApatosaurs = new List<GameObject>();
    public List<GameObject> treeStegosaurs = new List<GameObject>();

    int iteCount = 0;
    int [,]cells;
    int nextCellsY;
    bool stepped;
    bool generate;
    bool generatePlants;
    int numberOfTrees = 50;
    void Start()
    {
        generatePlants = true;
        generate = false;
        GenerateCA();
    }

    void Update()
    {
         //Condicion para que se cree el automata celular.
         //Ite se usa para generar n veces las generaciones.
        if(generate == true && iteCount < ite) {
            iteCount ++;
            int[,] nextCells = new int [rows, cols];
            //Se itera sobre todas las celdas para checar sus vecindarios(si en el vecindario de
            // la celda i hay mas de 5 unos, en la sig generacion la celda i va a valer 1).
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < cols; i++)
                {
                    int num = numOfFilledCells(i, j);
                    if(num >= 5)
                    {
                        nextCells[i, j] = 1;
                    }else{
                        nextCells[i, j] = 0;
                    }
                }
            }

            foreach(GameObject cell in oldCells)
            {
                Destroy(cell);
            }
             oldCells.Clear();
            cells = nextCells;
            //Se itera sobre todas las generaciones para saber si ponerle blanck o full.
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if(IsFilled(i, j) == 0){
                        oldCells.Add(Instantiate(blankCell, new Vector3(i, 0, j), Quaternion.identity));
                    } else if (IsFilled(i, j) == 1)
                    {
                        oldCells.Add(Instantiate(fullCell, new Vector3(i, -0.148f, j), Quaternion.identity));
                    }
                }
            }
        }   
        if(iteCount >= ite)
        {
            if(generatePlants == true)
            {
                foreach (GameObject tile in oldCells)
            {
                if(tile != null && tile.tag == "Pasto")
                {
                    grassTiles.Add(tile);
                }
            } 
            SpawnTrees(numberOfTrees, treePrefab1, treePrefab2, new Vector3(0, 0.239f, 0), new Vector3(0, 0.485f, 0));
            generatePlants = false;
            }
        }
    } 
     
   //Se crea una grid random de 1 y 0.
    void CreateCells(){
        for (int j = 0; j < rows; j++)
        {
            for (int i = 0; i < cols; i++)
            {
                cells[i, j] = Random.Range(0,2);
            }
        } 
    }

    //Te regresa el numero de unos que hay en i.
     int numOfFilledCells(int x, int y){
        int num = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if(IsFilled(x + i, y + j) == 1){
                    num++;
                }
            }
        }
        return num;
    }

    //Toma los valores de la UI y los guarda en variables.
    public void GenerateCA(){
    //rows = int.Parse(sizeX_IF.text);
   // cols = int.Parse(sizeY_IF.text);
    //ite = int.Parse(iteNumber_IF.text);
    generate = true;
    cells = new int[rows, cols];
    CreateCells();
    }

    //Devuelve si una celda esta llena o no.
    public int IsFilled(int x, int y){
    if (x < 0 || x >= cols || y < 0 || y >= rows) {
        return 0;
    } else { 
       // Debug.Log(x + ", " + y + " =" + cells[x, y]);
        return cells[x, y];
    }
    }

    public List<GameObject> GetCells()
    {
        return oldCells;
    }

    public void SpawnTrees(int numberOfTrees, GameObject treePrefab1, GameObject treePrefab2, Vector3 spawnOffset1, Vector3 spawnOffset2)
    {
         List<GameObject> spawnTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTrees; i++)
        {
            spawnTiles.Add(grassTiles[Random.Range(0, grassTiles.Count)]);
        }

        foreach (GameObject tile in spawnTiles)
        {
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                treeApatosaurs.Add(Instantiate(treePrefab1, tile.transform.position + spawnOffset1, Quaternion.identity));
            }
            else if(rand == 1)
            {
                treeStegosaurs.Add(Instantiate(treePrefab2, tile.transform.position + spawnOffset2, Quaternion.identity));
            }
        }
    }

}




    

