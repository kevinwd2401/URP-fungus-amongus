using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalCut : AttackSkill
{
    // Start is called before the first frame update
    public DiagonalCut()
    {
        // your move
        Vector2[] offsets = {
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
        };
        // your attack area
        (Vector2 coord, int dmg)[,] attackAreas = { // attackAreas.GetLength(0) = 4, attackAreas.GetLength(1) = area
            { (new Vector2(1, 1), 1) },
            { (new Vector2(-1, 1), 1)},
            { (new Vector2(1, -1), 1) },
            { (new Vector2(-1, -1), 1)},
        };

        // attack initated by human
        attack = new Attack("Diagonal Cut", false, offsets, attackAreas);
    }

}
