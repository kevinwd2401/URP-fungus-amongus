using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSkill : Skill
{
    public MotorSkill()
    {
        /* Motor skills are always pure motor skills */
        isMove = true;
        isAttack = false;
    }

    public void lunge(Vector2 currentPos, Vector2 targetPos)
    {
        /* automatic moving skill based on your move skill */
        Debug.Log("tried running");
    }
}
