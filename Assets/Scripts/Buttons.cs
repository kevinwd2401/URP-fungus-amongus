using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Deck deck;

    public Button button;
    public int numberOfDuplicates = 5;  // Number of duplicates to create
    public float interval = 80f;

    // Start is called before the first frame update
    //void Start()
    //{
    //    DuplicateButtons();
    //}

    //void DuplicateButtons()
    //{
    //    // Get the parent of the original button
    //    Transform parentTransform = button.transform.parent;

    //    // Starting position for the first duplicated button
    //    Vector3 startPosition = button.transform.position;

    //    for (int i = 1; i <= numberOfDuplicates; i++)
    //    {
    //        // Create a new button instance
    //        Button newButton = Instantiate(button, parentTransform);

    //        // Set the position with a 100-pixel interval on the y-axis
    //        newButton.transform.position = startPosition + new Vector3(interval * i, 0, 0);

    //        // Optionally, you can rename the button for identification
    //        newButton.name = button.name + "_Duplicate_" + i;
    //    }
    //}


    GameObject[] buttonPrefabs;

    List<GameObject> LoadedButtons = new List<GameObject>();

    void Start()
    {
        //LoadButtonPrefabs();
    }

    void LoadButtonPrefabs()
    {
        // Load all button prefabs from the "Resources/Buttons" folder
        buttonPrefabs = Resources.LoadAll<GameObject>("SkillButtons");

        for (int i = 0; i < 5; i++)
        {
            // Instantiate the button prefab
            GameObject newButton = Instantiate(buttonPrefabs[i], transform);

            // Optionally set the position or other properties
            newButton.transform.localPosition = new Vector3(i * interval, 0, 0); // Example positioning
            newButton.name = "Button_" + (i + 1); // Naming for identification
        }
    }

    public void ClearButtons() {
        foreach (GameObject b in LoadedButtons) {
            Destroy(b);
        }
        LoadedButtons.Clear();
    }

    public void LoadButtonAt( string name, int i) {

            GameObject newButton = Instantiate(Resources.Load<GameObject>("SkillButtons/" + name), transform);
            
            newButton.transform.localPosition = new Vector3(i * interval, 0, 0); // Example positioning
            newButton.name = "Button_" + (i + 1); // Naming for identification

            Skill s = newButton.GetComponent<Skill>();
            s.index_in_hand = i;
            s.buttons = this;
            s.mpCost = deck.hand[i].cost;

            LoadedButtons.Add(newButton);

    }

}
