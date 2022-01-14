using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;

    public Color greenColor;
    public Color redColor;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isOccupied)
        {
            spriteRenderer.color = redColor;
        }
        else
        {
            spriteRenderer.color = greenColor;
        }
    }
}
