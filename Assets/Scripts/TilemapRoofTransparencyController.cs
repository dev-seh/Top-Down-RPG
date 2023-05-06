using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapRoofTransparencyController : MonoBehaviour
{
    public Tilemap roofTilemap;
    public float transparentAlpha = 0.3f;


    private Color originalColor;


    private void Start()
    {
        originalColor = roofTilemap.color;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetRoofTransparency(transparentAlpha);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetRoofTransparency(originalColor.a);
        }
    }


    private void SetRoofTransparency(float alpha)
    {
        Color newColor = roofTilemap.color;
        newColor.a = alpha;
        roofTilemap.color = newColor;
    }
}




