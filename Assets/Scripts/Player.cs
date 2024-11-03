using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void attack(PlayerAttacks attackEnum) {
        switch(attackEnum) {
        case PlayerAttacks.SlashRight:
            (Vector2 coord, int dmg)[] attackOffsets = {(new Vector2(1, 0), 3), (new Vector2(1, 1), 3), (new Vector2(1, -1), 3)};
            useAttack(new Attack("SlashRight", false, attackOffsets));
            break;
        default:
            // code block
            break;
        }
    }

    void Update()
    {

    }
}

public enum PlayerAttacks {
    SlashRight, SlashLeft
}
