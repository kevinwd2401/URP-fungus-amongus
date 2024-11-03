using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSlash : AttackSkill
{
    // Start is called before the first frame update

    public SpinSlash()
    {
        // your attack
        Vector2[] offsets = {
            new Vector2(1, 0),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1),
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
        };
        // your attack area
        (Vector2 coord, int dmg)[,] attackAreas;

        attackAreas = new (Vector2, int)[8, 8];
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                attackAreas[i,j] = (offsets[j], 1);
        }
        }

        // attack initated by human
        attack = new Attack("Spin Slash", false, offsets, attackAreas);
    }
}
