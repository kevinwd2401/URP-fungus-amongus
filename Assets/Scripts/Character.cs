using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public GameObject spawnSparkPrefab;
    protected int hp;
    protected int mp;
    private Vector2 coords;

    public void useAttack(Attack a) {
        //go through list of attack offsets and damage the enemy on that tile if it exists.
        Vector2 dim = GameManager.Instance.boardDim;
        for (int j = 0; j < a.attackAreas.GetLength(1); j++)
        {
            (Vector2 attackCoord, int dmg) = a.attackAreas[a.chosenOffset, j];
            int x = (int) coords.x + (int) attackCoord.x;
            int y = (int) coords.y + (int) attackCoord.y;

            if (x < 0 || y < 0 || y >= dim.y || x >= dim.x)
            {
                continue;
            }
            GameManager.Instance.damageCharacterOnBoard(a.enemy, dmg, x, y);
        }
    }
    public void move(int xOffset, int yOffset) {
        coords.x = coords.x + xOffset;
        coords.y = coords.y + yOffset;
        //add reference to new tile
        GameManager.Instance.moveCharacterOnBoard(this, (int) coords.x, (int) coords.y);
        StartCoroutine(moveCor(xOffset, yOffset));
    }
    protected IEnumerator moveCor(int xOffset, int yOffset) {
        Vector3 pos = transform.position;
        Vector3 newPos = pos + new Vector3(xOffset * GameManager.Instance.tileLength, 0, yOffset * GameManager.Instance.tileLength);
        float timer = 0;
        while (timer < 0.5f) {
            yield return null;
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(pos, newPos, timer / 0.5f);
        }
    }
    public Vector2 getPos() {
        return coords;
    }

    public virtual Vector3 getWorldCoords()
    {
        return transform.position;
    }

    public void takeDamage(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            die();
        }
    }
    public virtual void die() {
        //delete reference from tile
        GameManager.Instance.deleteCharacterFromBoard(this);
    }

    public virtual void Initialize(Vector2 coords, int hp = -1)
    {
        this.coords = coords;
        this.hp = hp;
    }

    public void spawn(Vector2 worldPos)
    {
        transform.position = new Vector3(worldPos.x, 0, worldPos.y);
        if (spawnSparkPrefab != null) {
            GameObject spark = Instantiate(spawnSparkPrefab, transform.position, Quaternion.identity);
            Destroy(spark, 3);
        }
    }
}


public class Attack {
    public bool enemy;
    public string attackName;
    public int chosenOffset;
    public Vector2 [] attackOffsets;
    public (Vector2 coord, int dmg)[,] attackAreas; // getLength(0) = attackOffsets.Length, getLength(1) = area it covers

    public Attack(string name, bool enemy, Vector2[] attackOffsets, (Vector2 coord, int dmg)[,] attackAreas, int chosenOffset = -1) {
        this.chosenOffset = chosenOffset;
        this.attackOffsets = attackOffsets;
        this.attackAreas = attackAreas;
        attackName = name;
        this.enemy = enemy;
    }
}