using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarSlash : AttackSkill
{
    // Start is called before the first frame update


    public LunarSlash()
    {
        // your attack
        Vector2[] offsets = {
            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1),
        };
        // your attack area
        (Vector2 coord, int dmg)[,] attackAreas = { // attackAreas.GetLength(0) = 4, attackAreas.GetLength(1) = area
            { (new Vector2(1, 0), 2) , (new Vector2(2, 0), 2) , (new Vector2(3, 0), 2) , (new Vector2(4, 0), 2) },
            { (new Vector2(-1, 0), 2) , (new Vector2(-2, 0), 2) , (new Vector2(-3, 0), 2) , (new Vector2(-4, 0), 2) },
            { (new Vector2(0, 1), 2) , (new Vector2(0, 2), 2) , (new Vector2(0, 3), 2)  , (new Vector2(0, 4), 2) },
            { (new Vector2(0, -1), 2) , (new Vector2(0, -2), 2) , (new Vector2(0, -3), 2) , (new Vector2(0, -4), 2) },
        };

        // attack initated by human
        attack = new Attack("Lunar Slash", false, offsets, attackAreas);
    }
}
