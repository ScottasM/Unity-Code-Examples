using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;


    [Header("Settings")]
    [SerializeField] private float sizeOfTile;

    [Header("References")]
    [SerializeField] private GameObject tileSelector;
    [SerializeField] private TileDatabase tileDatabase;
    [SerializeField] private Tile tilePrefab;

    [Space]
    [Header("Debug information")]
    public Vector2Int selectorCoordinates;

    private int _selectedDatabase = 0;
    private List<Tile> _tileList = new List<Tile>();

    public void Awake()
    {
        instance = this;
    }


    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2Int currentCoordinates = new Vector2Int((int)Mathf.Floor(mouseWorldPos.x / sizeOfTile), (int)Mathf.Floor(mouseWorldPos.y/ sizeOfTile));
        if(currentCoordinates != selectorCoordinates) {
            selectorCoordinates = currentCoordinates;
            tileSelector.transform.position = GetVectorForCoordinates(selectorCoordinates);
        }

        if (Input.GetMouseButtonDown(0)) {
            Tile tileInstance = Instantiate(tilePrefab);
            _tileList.Add(tileInstance);
            tileInstance.coordinates = selectorCoordinates;
            tileInstance.spriteRenderer.sprite = tileDatabase.tiles[_selectedDatabase].sprite;
            tileInstance.transform.position = GetVectorForCoordinates(selectorCoordinates);
        }
    }


    public void RemoveTile(Tile tile)
    {
        Destroy(tile.gameObject);
        _tileList.Remove(tile);
    }

    public Vector3 GetVectorForCoordinates(Vector2Int coordinates)
    {
        return new Vector3(sizeOfTile / 2 + coordinates.x * sizeOfTile, sizeOfTile / 2 + coordinates.y * sizeOfTile, 0);
    }
}
