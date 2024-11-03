using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Skill
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

        // if you hover over an attack area, it should show area of attak.
        //ShowPotentialAttackArea();

        // if it is over the character, character will become slightly transparent.
        GameManager.Instance.TurnOnPlayerOpacity(true);


        // once the tile is clicked, then initate attack
        //Attack(playerWorldCoords);

        // turn it off after all is over
        //GameManager.Instance.TurnOnPlayerOpacity(false);
    }

    public void GeneratePotentialAttackPlaces(Vector3 playerWorldCoords)
    {
        Vector2 [] offsets = {
            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1),
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
        };
        (Vector2 coord, int dmg)[,] attackAreas = { // attackAreas.GetLength(0) = 4, attackAreas.GetLength(1) = area
            { (new Vector2(1, 0), 1) , (new Vector2(1, 1), 1) , (new Vector2(1, -1), 1) },
            { (new Vector2(-1, 0), 1), (new Vector2(-1, 1), 1), (new Vector2(-1, -1), 1) },
            { (new Vector2(0, 1), 1) , (new Vector2(1, 1), 1) , (new Vector2(-1, 1), 1) },
            { (new Vector2(0, -1), 1), (new Vector2(1, -1), 1), (new Vector2(-1, -1), 1) },
            { (new Vector2(1, 1), 1),  (new Vector2(0, 1), 1),  (new Vector2(1, 0), 1)  },
            { (new Vector2(-1, 1), 1), (new Vector2(0, 1), 1), (new Vector2(-1, 0), 1) },
            { (new Vector2(1, -1), 1), (new Vector2(0, -1), 1), (new Vector2(1, 0), 1) },
            { (new Vector2(-1, -1), 1),(new Vector2(0, -1), 1),(new Vector2(-1, 0), 1)},
        };

        //Debug.Log("herehere"+attackAreas.GetLength(0) + " " + attackAreas.GetLength(1));
        Attack attack = new Attack("Slash", false, offsets, attackAreas);
        attackDisplay.displayAttackedTiles(playerWorldCoords, attack, this);
    }

    public override void Attack(int id) //Vector3 playerWorldCoords)
    {
        //(Vector2 coord, int dmg)[] offsetes = { (new Vector2(1, 0), 1) };
        //Attack attack = new Attack("Slash", false, offsetes);

        //attackDisplay.displayAttackedTiles(playerWorldCoords, attack);
        //Debug.Log("slash clicked");

    }
}
