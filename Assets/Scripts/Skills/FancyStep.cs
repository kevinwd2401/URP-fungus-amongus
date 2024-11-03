using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyStep : MotorSkill
{
    // Start is called before the first frame update
    public FancyStep()
    {
        // your move
        Vector2[] offsets = {
            new Vector2(1, 2),
            new Vector2(-1, 2),
            new Vector2(2, 1),
            new Vector2(2, -1),
            new Vector2(1, -2),
            new Vector2(-1, -2),
            new Vector2(-2, 1),
            new Vector2(-2, -1),
        };
        // your attack area
        (Vector2 coord, int dmg)[,] attackAreas = { // attackAreas.GetLength(0) = 4, attackAreas.GetLength(1) = area
            { (new Vector2(1, 2), 0) },
            { (new Vector2(-1, 2), 0)},
            { (new Vector2(2, 1), 0) },
            { (new Vector2(2, -1), 0)},
            { (new Vector2(1, -2), 0) },
            { (new Vector2(-1, -2), 0)},
            { (new Vector2(-2, 1), 0) },
            { (new Vector2(-2, -1), 0)},
        };

        // attack initated by human
        attack = new Attack("Fancy Step", false, offsets, attackAreas);
    }

}
