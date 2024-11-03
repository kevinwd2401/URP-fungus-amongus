using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public void Click() {
        GameManager.Instance.playerEndTurn();
    }

}
