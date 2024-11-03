using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int index_in_hand;
    public Buttons buttons;

    protected Vector3 characterWorldCoords;
    protected AttackTileDisplayer attackDisplay;
    protected Attack attack;
    public bool isAttack = true;
    public bool isMove = false;
    private bool cleanedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        attackDisplay = GameManager.Instance.gameObject.GetComponent<AttackTileDisplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Assault(Vector3 enemyWorldCoords)
    // monster version of attack
    {
        /* should have monster's ability to attack */
        if (attack != null)
        {
            attack.enemy = true;
        }
    }

    public void Click()
    {
        //Debug.Log("herehere"+attackAreas.GetLength(0) + " " + attackAreas.GetLength(1));
        characterWorldCoords = GameManager.Instance.getPlayerWorldCoords();
        attack.enemy = false;

        // if it is over the character, character will become slightly transparent.
        GameManager.Instance.TurnOnPlayerOpacity(true);

        // generate potential places to click
        GeneratePotentialAttackPlaces(characterWorldCoords);

        // once the tile is clicked, then initate attack
        //Attack(playerWorldCoords);

        //GameManager.Instance.TurnOnPlayerOpacity(false);
    }


    public void GeneratePotentialAttackPlaces(Vector3 characterWorldCoords)
    {
        attackDisplay.displayAttackedTiles(characterWorldCoords, attack, this);
    }

    public void Attack(int coord_id) //Vector3 playerWorldCoords)
    {
        // know which attack it uses
        attack.chosenOffset = coord_id;
        GameManager.Instance.playerAttacks(attack);
        Debug.Log("attacking from skill");

    }

    public void Move(int coord_id)
    {
        // know which move it uses
        attack.chosenOffset = coord_id;
        GameManager.Instance.playerMoves(attack);
        Debug.Log("mmoving from skill");
    }

    public void CleanUpAfterAction()
    {

        if (cleanedUp) return;

        // turn it off after all is over
        GameManager.Instance.TurnOnPlayerOpacity(false);

        // clear attackTileDisplay
        attackDisplay.clearUI();

        // remove card from deck
        removeFromHand();

        cleanedUp = true;

    }

    //remove from hand
    void removeFromHand() {
        buttons.deck.discardByIndex(index_in_hand);
    }
}
