using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTileDisplayer : MonoBehaviour
{
    public GameObject selectedUIPrefab;
    public GameObject selectedUIPrefab2;
    List<GameObject> UIList; // ui list that shows point of attack
    GameObject [,] UI2List; // ui litst that shows area of attack
    const int maxAreaAttack = 9;

    void Start() {
        UIList = new List<GameObject>();
    }
    public void clearUI() {
        foreach (GameObject go in UIList) {
            Destroy(go);
        }
        UIList.Clear();
        if (UI2List != null)
        {
            foreach (GameObject go in UI2List)
            {
                Destroy(go);
            }
        }
    }
    // Start is called before the first frame update
    public void displayAttackedTiles(Vector3 worldPos, Attack a)
    /* attackArea: attack blocks i per attack j */
    {
        clearUI();
        UI2List = new GameObject[a.attackAreas.GetLength(0), a.attackAreas.GetLength(1)]; 

        for (int i = 0; i < a.attackOffsets.Length; i++)
        {
            // instantiate attack point
            Vector2 attack_coord = a.attackOffsets[i];
            Vector3 newPos = worldPos + GameManager.Instance.tileLength * new Vector3(attack_coord.x, 0f, attack_coord.y);
            GameObject ui = Instantiate(selectedUIPrefab, newPos, Quaternion.identity);
            UIList.Add(ui);

            // instantiate attack area
            for (int j = 0; j < a.attackAreas.GetLength(1); j++)
            {
                (Vector2 attack_area_coord, int dmg) = a.attackAreas[i,j];
                Vector3 newPos2 = worldPos + GameManager.Instance.tileLength * new Vector3(attack_area_coord.x, 0f, attack_area_coord.y);
                GameObject ui2 = Instantiate(selectedUIPrefab2, newPos2, Quaternion.identity);
                UI2List[i,j] = ui2;
            }
        }
    }
}
