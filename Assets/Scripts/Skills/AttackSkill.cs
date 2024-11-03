using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : Skill
{
    /* Action skills are always action, but can have movement */

    public AttackSkill()
    {
        isAttack = true;
    }

    public bool sabotage(Vector2 currentPos, Vector2 targetPos)
    {
        /* automatic attacking skill based on your action skill, 
         * return whether it successfully sabotaged a player or not */
        Debug.Log("tried sabotage");


        // if it wasn't satisfactory it will move to move.
        return false;
    }
}
