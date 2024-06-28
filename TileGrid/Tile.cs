using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer spriteRenderer;

    [Header("Debug information")]
    public Vector2Int coordinates;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
