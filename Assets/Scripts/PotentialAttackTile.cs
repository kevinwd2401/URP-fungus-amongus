using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentialAttackTile : MonoBehaviour
{
    private bool isHovering;
    private int id = -1; // id of the
    AttackTileDisplayer attackDisplayer ; // id of the 
    // Start is called before the first frame update
    void Start()
    {
        isHovering = false;
    }

    public void initalize(int id, AttackTileDisplayer attackDisplayer)
    {
        this.id = id;
        this.attackDisplayer = attackDisplayer;
    }

    private void Update()
    {
        
    }

    void OnMouseEnter()
    {
        // When the mouse enters, set isHovering to true
        isHovering = true;
        attackDisplayer.displayAttackArea(id, true);
    }

    void OnMouseExit()
    {
        // When the mouse exits, set isHovering to false
        isHovering = false;
        attackDisplayer.displayAttackArea(id, false);
    }

    void OnMouseDown()
    {
        // When the mouse exits, set isHovering to false
        attackDisplayer.initaiteAttack(id);
    }


}
