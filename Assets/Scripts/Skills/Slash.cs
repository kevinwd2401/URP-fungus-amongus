using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    // Start is called before the first frame update
    AttackTileDisplayer attackDisplay;
    void Start()
    {
        attackDisplay = GameManager.Instance.gameObject.GetComponent<AttackTileDisplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Vector3 playerWorldCoords = GameManager.Instance.getPlayerWorldCoords();

        // generate potential places to click
        GeneratePotentialAttackPlaces(playerWorldCoords);

        // the mouse will rotate radially around
        // if it is over the character, character will become slightly transparent.
        GameManager.Instance.TurnOnPlayerOpacity(true);


        // once the tile is clicked, then initate attack
        //Attack(playerWorldCoords);

        // turn it off after all is over
        //GameManager.Instance.TurnOnPlayerOpacity(false);
    }

    public void GeneratePotentialAttackPlaces(Vector3 playerWorldCoords)
    {
        (Vector2 coord, int dmg)[] offsetes = {
            (new Vector2(1, 0), 0),
            (new Vector2(-1, 0), 0),
            (new Vector2(0, 1), 0),
            (new Vector2(0, -1), 0),
        };
        Attack fakeAttack = new Attack("", false, offsetes);
        attackDisplay.displayAttackedTiles(playerWorldCoords, fakeAttack);
        Debug.Log("genrated potential area");
    }

    public void Attack(Vector3 playerWorldCoords)
    {
        (Vector2 coord, int dmg)[] offsetes = { (new Vector2(1, 0), 1) };
        Attack attack = new Attack("Slash", false, offsetes);

        attackDisplay.displayAttackedTiles(playerWorldCoords, attack);
        Debug.Log("slash clicked");

    }
}
