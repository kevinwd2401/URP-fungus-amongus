using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalStep : Skill
{
    // Start is called before the first frame update
    public DiagonalStep()
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
            { (new Vector2(1, 1), 0) },
            { (new Vector2(-1, 1), 0)},
            { (new Vector2(1, -1), 0) },
            { (new Vector2(-1, -1), 0)},
        };

        isMove = true;
        isAttack = false;

        // attack initated by human
        attack = new Attack("Horizontal Step", false, offsets, attackAreas);
    }

}
