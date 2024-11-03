using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTileDisplayer : MonoBehaviour
{
    public GameObject selectedUIPrefab;
    List<GameObject> UIList;
    void Start() {
        UIList = new List<GameObject>();
    }
    public void clearUI() {
        foreach (GameObject go in UIList) {
            Destroy(go);
        }
        UIList.Clear();
    }
    // Start is called before the first frame update
    public void displayAttackedTiles(Vector3 worldPos, Attack a) {
        clearUI();
        foreach ((Vector2 coord, int dmg) att in a.attackOffsets) {
            Vector3 newPos = worldPos + GameManager.Instance.tileLength * new Vector3(att.coord.x, 0.3f, att.coord.y);
            GameObject ui = Instantiate(selectedUIPrefab, newPos, Quaternion.identity);
            UIList.Add(ui);
        }
    }
}
