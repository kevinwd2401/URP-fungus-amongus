using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int index_in_hand;
    public Buttons buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //remove from hand
    void removeFromHand() {
        buttons.deck.discardByIndex(index_in_hand);
    }
}
