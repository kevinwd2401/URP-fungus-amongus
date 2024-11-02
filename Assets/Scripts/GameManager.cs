using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // making it singleton
    public Board board;
    public static GameManager Instance { get; private set; }

    public Vector2 boardDim
    {
        get
        {
            return new Vector2(board.lengthBin, board.widthBin);
        }
    }
    public float tileLength
    {
        get
        {
            return board.length / board.lengthBin;
        }
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void moveCharacterOnBoard(Character character, int x, int y)
    {
        //delete reference from original tile first
        Debug.Log("Moving character on Board");
    }
    public void deleteCharacterFromBoard(Character character)
    {
        Debug.Log("Deleting character on Board");
        Destroy(character.gameObject);
    }

    public void damageCharacterOnBoard(bool enemy, int dmg, int x, int y)
    {
        Debug.Log("Damaging character on Board");
        
    }

    public void initiate()
    {
        //// wipe board
        //board.Wipe();

        //// create tiles
        //board.CreateTiles();

        //// spawn player

        //// spawn enemy
    }

}
