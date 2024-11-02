using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] tiles;
    public float length = 100;
    public float width = 100;
    public int lengthBin = 100;
    public int widthBin = 100;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    Vector2[,] tilePos; // position refers to float coordinate x,y
    int[,] tileIds;
    Character[,] characterCoords; // location refer to integer location i,j

    // Start is called before the first frame update
    void Start()
    {
        Wipe();
        CreateTiles();
        SpawnPlayer(Vector2.zero);
        SpawnEnemy(new Vector2(51,51));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTiles()
    {
        int[] ids = { 1, 1, 0 };
        float[] probabilities = { 0.05f, 0.05f, 0.9f };
        tileIds = createTilePatterns(ids, probabilities);

        tilePos = new Vector2[lengthBin, widthBin];
        for (int i = 0; i < lengthBin; i++)
        {
            for (int j = 0; j < widthBin; j++)
            {
                // Set the Vector2 location for each tile (i, j)
                float x = i * (length / lengthBin) - (length / 2);
                float y = j * (width / widthBin) - (width / 2);
                tilePos[i, j] = new Vector2(x, y);
                int id = tileIds[i, j];
                GameObject quadInstance = Instantiate(tiles[id], transform);
                quadInstance.transform.localPosition = new Vector3(x, 0, y);
                quadInstance.transform.localRotation = Quaternion.identity;
            }
        }
    }



    public void Wipe()
    {
        characterCoords = new Character[lengthBin, widthBin];
    }

    public void SpawnPlayer(Vector2 coord)
    {

    }

    public void SpawnEnemy(Vector2 coords, string enemyType = "", int level = 1, int hp = -1)
    {
        Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
        enemy.Initialize(coords, enemyType, level, hp);

        // spawn it
        int i = (int) coords.x;
        int j = (int) coords.y;
        characterCoords[i, j] = enemy;
        enemy.spawn(tilePos[i,j]);
    }


    int[,] createTilePatterns(int [] id, float [] probability)
    /* 
     * id and probablitly size should match 
     * probability = in the [0.1,0.2,0.7] need to add up to 1
     */
    {
        // recaclulate probability


        int[,] tilePatterns = new int[lengthBin, widthBin];
        for (int i = 0; i < lengthBin; i++)
        {
            for (int j = 0; j < widthBin; j++)
            {
                float randNumber = Random.value;
                float summedProb = 0;
                for (int k = 0; k < id.Length; k++)
                {
                    summedProb += probability[k];
                    if (randNumber < summedProb)
                    {
                        tilePatterns[i, j] = id[k];
                        break;
                    }
                }
            }
        }
        return tilePatterns;

    }
}
