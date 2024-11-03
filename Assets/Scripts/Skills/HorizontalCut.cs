using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCut : AttackSkill
{
    // Start is called before the first frame update
    public HorizontalCut()
    {
        // your move
        Vector2[] offsets = {
            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1),
        };
        // your attack area
        (Vector2 coord, int dmg)[,] attackAreas = { // attackAreas.GetLength(0) = 4, attackAreas.GetLength(1) = area
            { (new Vector2(1, 0), 1) },
            { (new Vector2(-1, 0), 1)},
            { (new Vector2(0, 1), 1) },
            { (new Vector2(0, -1), 1)},
        };

        // attack initated by human
        attack = new Attack("Horizontal Cut", false, offsets, attackAreas);
    }

}
