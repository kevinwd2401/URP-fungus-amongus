using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpacity : MonoBehaviour
{

    public float fadeSpeed = 3f;      // Speed of fading
    public float targetAlpha = 0.3f;    // Target alpha value when hovered

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isHovering = false;
    private bool opacityOn = false;

    void Start()
    {
        // Get the SpriteRenderer component and store the original color
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // if the current color is already there and opacity is turned off don't bother touching
        Color color = spriteRenderer.color;
        float desiredAlpha = originalColor.a;
        if (!opacityOn && color.a == originalColor.a) return;


        // if the opacity is on Determine the target alpha based on whether the mouse is hovering
        if (opacityOn)
        {
            desiredAlpha = isHovering ? targetAlpha : originalColor.a;
        }
        

        // Smoothly adjust the current alpha towards the target alpha
        
        color.a = Mathf.MoveTowards(color.a, desiredAlpha, fadeSpeed * Time.deltaTime);
        spriteRenderer.color = color;
    }

    void OnMouseEnter()
    {
        // When the mouse enters, set isHovering to true
        isHovering = true;
    }

    void OnMouseExit()
    {
        // When the mouse exits, set isHovering to false
        isHovering = false;
    }

    public void TurnOnInteractiveTransparency(bool on)
    {
        opacityOn = on;
    }
}
