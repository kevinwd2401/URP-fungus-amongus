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
    public GameObject[] enemyPrefabs;
    public GameObject playerPrefab;
    public GameObject[] baseTilePrefabs;
    Player player;

    Vector2[,] tilePos; // position refers to float coordinate x,y
    int[,] randomizedTilePattern;
    Character[,] characterCoords; // location refer to integer location i,j
    Dictionary<string, GameObject> name2Prefab = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initiate()
    {
        getEnemyPrefabs();
        Wipe();
        CreateTiles();
        SpawnPlayer(new Vector2(lengthBin / 2, widthBin / 2));
        string[] enemyType = { "Slimo", "Slimo", "Shroomie", "Dragoshroom" };
        SpawnEnemies(1, 5, enemyType);
    }

    void getEnemyPrefabs()
    {
        // Load all button prefabs from the "Resources/Buttons" folder
        enemyPrefabs = Resources.LoadAll<GameObject>("Enemy");
        foreach (GameObject prefab in enemyPrefabs)
        {
            Debug.Log(prefab.name);
            name2Prefab.Add(prefab.name, prefab);
        }
    }

    public void CreateTiles()
    {
        int[] tileIds = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        float[] tileProbabilities = { 0.9f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.02f };
        randomizedTilePattern = createTilePatterns(tileIds, tileProbabilities);


        tilePos = new Vector2[lengthBin, widthBin];
        for (int i = 0; i < lengthBin; i++)
        {
            for (int j = 0; j < widthBin; j++)
            {
                // Set the Vector2 location for each tile (i, j)
                float x = i * (length / lengthBin) - (length / 2);
                float y = j * (width / widthBin) - (width / 2);
                tilePos[i, j] = new Vector2(x, y);
                int id = randomizedTilePattern[i, j];
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

    public void SpawnPlayer(Vector2 coords)
    {
        player = Instantiate(playerPrefab).GetComponent<Player>();
        player.Initialize(coords, 100);
    }

    public void SpawnEnemy(Vector2 coords, string enemyType = "", int level = 1, int hp = -1)
    {

        Enemy enemy = Instantiate(name2Prefab[enemyType]).GetComponent<Enemy>();
        enemy.Initialize(coords, enemyType, level, hp);

        // spawn it
        int i = (int) coords.x;
        int j = (int) coords.y;
        characterCoords[i, j] = enemy;
        enemy.spawn(tilePos[i,j]);
    }

    public void SpawnEnemies(int innerRadius, int outerRadius, string[] enemyTypes)
    {
        for (int i= 0; i < enemyTypes.Length; i++)
        {
            int width = Random.Range(innerRadius, outerRadius);
            int length = Random.Range(innerRadius, outerRadius);
            int wSign = Random.Range(0, 2) * 2 - 1;
            int lSign = Random.Range(0, 2) * 2 - 1;
            int ii = width * wSign;
            int jj = length * lSign;
            Vector2 pos = player.getPos();
            int x = (int)Mathf.Clamp(pos.x + ii, 0f, lengthBin);
            int y = (int)Mathf.Clamp(pos.y + jj, 0f, widthBin);
            Debug.Log(x + " " + y);
            SpawnEnemy(new Vector2(x, y), enemyTypes[i]);
        }
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
