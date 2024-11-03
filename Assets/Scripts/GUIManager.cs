using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text HpNum;
    public Image mpImg;
    public Image mpmaxImg;

    public Sprite mx3;
    public Sprite mx4;
    public Sprite mx5;
    public Sprite m0;
    public Sprite m1;
    public Sprite m2;
    public Sprite m3;
    public Sprite m4;
    public Sprite m5;

    public void updateMP(int mp, int max) {
        
        if (max == 3) mpmaxImg.sprite = mx3;
        if (max == 4) mpmaxImg.sprite = mx4;
        if (max == 5) mpmaxImg.sprite = mx5;
        if (mp == 0) mpImg.sprite = m0;
        if (mp == 1) mpImg.sprite = m1;
        if (mp == 2) mpImg.sprite = m2;
        if (mp == 3) mpImg.sprite = m3;
        if (mp == 4) mpImg.sprite = m4;
        if (mp == 5) mpImg.sprite = m5;

    }
    public void updateHP(int hp) {
        
        HpNum.text = hp.ToString(); 

    }

    // Start is called before the first frame update
    void Start()
    {
        //Test Code
        updateHP(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
