using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Vector2 coords, string enemyType = "", int level = 1, int hp = -1)
    {
        base.Initialize(coords, hp);
    }

}
