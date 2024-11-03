using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : Character
{
    public GameObject damageSparkPrefab, deathSparkPrefab;
    public int level;

    public Vector2[] offsets = {
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 1),
        new Vector2(-1, 1),
        new Vector2(-1, -1),
        new Vector2(1, -1),
    };

    // Start is called before the first frame update
    void Start()
    {
        hp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void takeDamage(int dmg) {
        GameObject popup = Instantiate(dmgPopupPrefab, transform.position + 1.2f * Vector3.up, Quaternion.identity);
        popup.GetComponent<TextMeshPro>().text = "-" + dmg;

        hp -= dmg;
        if (hp <= 0) {
            die();
        } else if (damageSparkPrefab != null) {
            GameObject spark = Instantiate(spawnSparkPrefab, transform.position, Quaternion.identity);
            Destroy(spark, 3);
        }
        
    }
    public override void die() {
        //delete reference from tile
        GameObject spark = Instantiate(deathSparkPrefab, transform.position, Quaternion.identity);
        Destroy(spark, 3);
        GameManager.Instance.deleteCharacterFromBoard(this);
    }

    public void Initialize(Vector2 coords, string enemyType = "", int level = 1, int hp = -1)
    {
        base.Initialize(coords, hp);
    }

}
