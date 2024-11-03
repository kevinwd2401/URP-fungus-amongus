using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    Text HpNum;
    Image mp;
    Image mpmax;

    public void updateMP(int mp, int max) {
        
        string mpfile = "gui_mana_" + mp.ToString();
        string mpmaxfile = "gui_maxmana_" + max.ToString();

    }
    public void updateHP(int hp) {
        
        HpNum.text = hp.ToString(); 

    }

    // Start is called before the first frame update
    void Start()
    {
        //Test Code
        updateHP(3);
        updateMP(4,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
