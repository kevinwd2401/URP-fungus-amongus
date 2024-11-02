using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int hp;
    protected int mp;
    private Vector2 coords;

    public void useAttack(Attack a) {
        //go through list of attack offsets and damage the enemy on that tile if it exists.
        foreach ((Vector2 coord, int dmg) att in a.attackOffsets) {
            int x = (int) coords.x + (int) att.coord.x;
            int y = (int) coords.y + (int) att.coord.y;
            if (x < 0 || y < 0 || y > 99 || x > 99) {
                continue;
            }
            GameManager.Instance.damageCharacterOnBoard(a.enemy, att.dmg, x, y);
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

    public void spawn(Vector2 worldPos) {
        //spawn sparks
        transform.position = new Vector3(worldPos.x, 0, worldPos.y);
    }
}


public class Attack {
    public bool enemy;
    public string attackName;
    public (Vector2 coord, int dmg)[] attackOffsets;

    public Attack(string name, bool enemy, (Vector2 coord, int dmg)[] attackOffsets) {
        this.attackOffsets = attackOffsets;
        attackName = name;
        this.enemy = enemy;
    }
}