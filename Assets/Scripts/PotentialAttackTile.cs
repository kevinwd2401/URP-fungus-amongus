using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentialAttackTile : MonoBehaviour
{
    private bool isHovering;
    private int id; // id of the
    AttackTileDisplayer attackDisplayer ; // id of the 
    // Start is called before the first frame update
    void Start()
    {
        id = -1;
        isHovering = false;
    }

    public void initalize(int id, AttackTileDisplayer attackDisplayer)
    {
        this.id = id;
        this.attackDisplayer = attackDisplayer;
        Debug.Log(id + " generated potential space");
    }

    private void Update()
    {
        
    }

    void OnMouseEnter()
    {
        // When the mouse enters, set isHovering to true
        isHovering = true;
        attackDisplayer.displayAttackArea(id, true);
        Debug.Log("Entered");
    }

    void OnMouseExit()
    {
        // When the mouse exits, set isHovering to false
        isHovering = false;
        attackDisplayer.displayAttackArea(id, false);
    }


}
