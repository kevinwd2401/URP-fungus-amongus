using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text HpNum;
    public Image mp;
    public Image mpmax;

    public Sprite mx3;
    public Sprite mx4;
    public Sprite mx5;
    public Sprite m1;
    public Sprite m2;
    public Sprite m3;
    public Sprite m4;
    public Sprite m5;

    public void updateMP(int mp, int max) {
        
        if (max == 3) mpmax.sprite = mx3;
        if (max == 4) mpmax.sprite = mx4;
        if (max == 5) mpmax.sprite = mx5;
        if (mp == 1) mpmax.sprite = m1;
        if (mp == 2) mpmax.sprite = m2;
        if (mp == 3) mpmax.sprite = m3;
        if (mp == 4) mpmax.sprite = m4;
        if (mp == 5) mpmax.sprite = m5;

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
