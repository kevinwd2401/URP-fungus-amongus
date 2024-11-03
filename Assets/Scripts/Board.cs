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
    public GameObject[] propPrefabs;
    public GameObject playerPrefab;
    public GameObject[] baseTilePrefabs;
    Player player;

    Vector2[,] tilePos; // position refers to float coordinate x,y
    int[,] randomizedTilePattern;
    int[,] randomizedPropPattern;
    public Character[,] characterCoords; // location refer to integer location i,j
    Dictionary<string, GameObject> name2Prefab = new Dictionary<string, GameObject>();


    public bool isTileOccupied(int x, int y) {
        if (x < 0 || y < 0 || x >= width || y >= widthBin) return false;
        return (characterCoords[x, y] != null);
    }
    public void DamageCharacterOnBoard(bool attackIsEnemy, int dmg, int x, int y)
    {
        Character character = characterCoords[x, y];
        if (character == null) return;
        if (attackIsEnemy && character.tag == "Enemy") return;
        character.takeDamage(dmg);
        Debug.Log("Damaging character on Board " + dmg);
    }

    public void initiate()
    {
        getEnemyPrefabs();
        getPropPrefabs();
        Wipe();
        CreateTiles();

        SpawnProps();

        SpawnPlayer(new Vector2(lengthBin / 2, widthBin / 2));

        string[] enemyType = { "Slimo", "Mush Mush", "Shroomy Longleg", "Shroomie", "Dragoshroom", "Sluggo" };
        SpawnEnemies(1, 5, enemyType);
    }

    void getEnemyPrefabs()
    {
        // Load all button prefabs from the "Resources/Buttons" folder
        enemyPrefabs = Resources.LoadAll<GameObject>("Enemy");
        foreach (GameObject prefab in enemyPrefabs)
        {
            //Debug.Log(prefab.name);
            name2Prefab.Add(prefab.name, prefab);
        }
    }
    void getPropPrefabs()
    {
        // Load all button prefabs from the "Resources/Buttons" folder
        propPrefabs = Resources.LoadAll<GameObject>("Props");
        foreach (GameObject prefab in propPrefabs)
        {
            //Debug.Log(prefab.name);
            name2Prefab.Add(prefab.name, prefab);
        }
    }

    public void CreateTiles()
    {
        int[] tileIds = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        float[] tileProbabilities = { 0.05f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.2f, 0.2f, 0.2f, 0.05f };
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
    public void SpawnProp(Vector2 coords, string propType = "", bool collision = true, int level = 1, int hp = -1)
    {

        Props prop = Instantiate(name2Prefab[propType]).GetComponent<Props>();
        prop.Initialize(coords, propType, level, hp);

        // spawn it
        int i = (int) coords.x;
        int j = (int) coords.y;

        if (collision) {
            characterCoords[i, j] = prop;
        }

        prop.spawn(tilePos[i,j]);
    }
    public void SpawnProps() {
        int[] tileIds = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        bool[] tileCollisionBools = { false, true, true, true, true, true, true, false, false, false, false };
        float[] tileProbabilities = { 0.9f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.01f};
        
        //First Entry's value is the rest (sum = 1)
        float pRest = 1.0f;
        for (int i = 1; i < tileProbabilities.Length; i++) {
            pRest -= tileProbabilities[i];
        }
        tileProbabilities[0] = pRest;
        
        randomizedPropPattern = createTilePatterns(tileIds, tileProbabilities);
        string[] PropTypes = {"NONE", "PropRock 1", "PropRock 2", "PropRock 3", "PropRock 4", "PropRock 5", "PropRock 6", "PropGrass 1", "PropGrass 2", "PropGrass 3", "PropGrass 4"};

        //Make sure that nothing spawns on the players
        randomizedPropPattern[lengthBin / 2, widthBin / 2] = 0;

        //for each tile: spawn the props
        for(int i = 0; i < randomizedPropPattern.GetLength(0); i++) {
            for(int j = 0; j < randomizedPropPattern.GetLength(1); j++) {
                int tileRandomResult = randomizedPropPattern[i,j];
                if (tileRandomResult > 0) {
                    SpawnProp(new Vector2(i, j), PropTypes[tileRandomResult], tileCollisionBools[tileRandomResult]);
                }
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

        // spawn it
        int i = (int)coords.x;
        int j = (int)coords.y;
        characterCoords[i, j] = player;
        player.spawn(tilePos[i, j]);
    }

    public void SpawnEnemy(Vector2 coords, string enemyType = "", int level = 1, int hp = -1)
    {
        // check occupancy
        int i = (int)coords.x;
        int j = (int)coords.y;
        if (characterCoords[i, j] != null) return;

        Enemy enemy = Instantiate(name2Prefab[enemyType]).GetComponent<Enemy>();
        enemy.Initialize(coords, enemyType, level, hp);

        // spawn it
        characterCoords[i, j] = enemy;
        enemy.spawn(tilePos[i, j]);
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
            //Debug.Log(x + " " + y);

            if (! isTileOccupied(x, y)) {
                SpawnEnemy(new Vector2(x, y), enemyTypes[i]);
            }
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
