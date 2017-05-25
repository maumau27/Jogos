using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class BoardManager: MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count houseCount = new Count(2, 4);
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] Houses;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialliseList()
    {
        gridPositions.Clear();

        for(int x = 1; x < columns - 1; x++)
        {
            for(int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for(int x = -1; x < columns + 1; x++)
        {
            for(int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randemIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randemIndex];
        gridPositions.RemoveAt(randemIndex);

        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene()
    {
        BoardSetup();
        InitialliseList();
        LayoutObjectAtRandom(Houses, houseCount.minimum, houseCount.maximum);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
