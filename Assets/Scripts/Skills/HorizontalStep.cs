using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalStep : Skill
{
    // Start is called before the first frame update
    void Start()
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
            { (new Vector2(1, 0), 0) },
            { (new Vector2(-1, 0), 0)},
            { (new Vector2(0, 1), 0) },
            { (new Vector2(0, -1), 0)},
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
