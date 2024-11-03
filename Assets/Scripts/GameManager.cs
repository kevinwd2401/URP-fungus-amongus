using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // making it singleton
    public Board board;
    public static GameManager Instance { get; private set; }
    private GameObject player;

    public GUIManager gui;

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
        board.initiate();
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().setMpmax(4);
        player.GetComponent<Player>().fillMp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPlayerWorldCoords()
    {
        return player.GetComponent<Player>().getWorldCoords();
    }

    public Vector3 getPlayerCoords()
    {
        return player.GetComponent<Player>().getPos();
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


    public void damageCharacterOnBoard(bool attackerIsEnemy, int dmg, int x, int y)
    {
        board.DamageCharacterOnBoard(attackerIsEnemy, dmg, x, y);
    }

    public void TurnOnPlayerOpacity(bool on)
    {
        player.GetComponent<Player>().TurnOnInteractiveTransparency(on);
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

    public void playerAttacks(Attack a)
    {
        player.GetComponent<Player>().useAttack(a);
    }

    public void playerMoves(Attack move)
    {

        Debug.Log("Tried Moving");
        Vector2 moveCoord = move.attackOffsets[move.chosenOffset];
        player.GetComponent<Player>().move((int) moveCoord.x, (int) moveCoord.y);
    }

<<<<<<< HEAD
    public int getPlayerMP() {
        return player.GetComponent<Player>().getMp();
    }
    public void setPlayerMP(int mpnew) {
        player.GetComponent<Player>().setMp(mpnew);
        gui.updateMP(mpnew, player.GetComponent<Player>().getMpmax());
    }
    public void setPlayerMpmax(int mpmaxnew) {
        player.GetComponent<Player>().setMpmax(mpmaxnew);
        gui.updateMP(player.GetComponent<Player>().getMp(), mpmaxnew);
    }
    public void notifyPlayerNoMp() {
        return;
    }

=======
    public void enemiesTurn()
    {
        /* Now enemy gets to attack */
        // get list of all enemies present
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("ENEMY ALARM");
            MotorSkill mSkill = enemy.GetComponent<MotorSkill>();
            AttackSkill aSkill = enemy.GetComponent<AttackSkill>();
            
            Vector2 currentPos = enemy.GetComponent<Enemy>().getPos();
            Vector2 targetPos = getPlayerCoords();

            // attack if you can
            bool success = false;
            if (aSkill != null) success = aSkill.sabotage(currentPos, targetPos);
            // move if you can't
            if (mSkill != null && !success) mSkill.lunge(currentPos, targetPos);
        }

    }
>>>>>>> 74e63f4 (motor skill and attack skill made for enemy phase)
}
