using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    public Transform player; // Referência ao transform do personagem
    public GameObject tilePrefab; // Prefab do tile
    public Vector2 loadDistance = new Vector2(5f, 5f); // Distâncias de carregamento dos tiles nos eixos X e Y
    public Vector2 unloadDistance = new Vector2(10f, 10f); // Distâncias de descarregamento dos tiles nos eixos X e Y
    public Vector2 tileSpacing = new Vector2(10f, 10f); // Espaçamento entre os tiles nos eixos X e Y

    private Vector2 lastLoadedTile;
    private Dictionary<Vector2, GameObject> loadedTiles = new Dictionary<Vector2, GameObject>();

    private void Start()
    {
        lastLoadedTile = WorldToTileCoords(player.position);
        LoadTilesAround(lastLoadedTile);
    }

    private void Update()
    {
        Vector2 currentTile = WorldToTileCoords(player.position);

        if (currentTile != lastLoadedTile)
        {
            LoadTilesAround(currentTile);
            UnloadTilesOutsideRange(currentTile);
            lastLoadedTile = currentTile;
        }
    }

    private Vector2 WorldToTileCoords(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / tileSpacing.x);
        int y = Mathf.FloorToInt(worldPosition.y / tileSpacing.y);
        return new Vector2(x, y);
    }

    private void LoadTilesAround(Vector2 centerTile)
    {
        for (int x = (int)centerTile.x - Mathf.CeilToInt(loadDistance.x); x <= centerTile.x + Mathf.CeilToInt(loadDistance.x); x++)
        {
            for (int y = (int)centerTile.y - Mathf.CeilToInt(loadDistance.y); y <= centerTile.y + Mathf.CeilToInt(loadDistance.y); y++)
            {
                Vector2 tileCoords = new Vector2(x, y);
                if (!loadedTiles.ContainsKey(tileCoords))
                {
                    Vector3 tilePosition = new Vector3(x * tileSpacing.x, y * tileSpacing.y, 0);
                    GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);

                    newTile.transform.SetParent(this.transform);
                    loadedTiles.Add(tileCoords, newTile);
                }
            }
        }
    }

    private void UnloadTilesOutsideRange(Vector2 centerTile)
    {
        List<Vector2> tilesToRemove = new List<Vector2>();
        foreach (var loadedTile in loadedTiles)
        {
            if (Mathf.Abs(centerTile.x - loadedTile.Key.x) > unloadDistance.x || Mathf.Abs(centerTile.y - loadedTile.Key.y) > unloadDistance.y)
            {
                Destroy(loadedTile.Value);
                tilesToRemove.Add(loadedTile.Key);
            }
        }

        foreach (var tileToRemove in tilesToRemove)
        {
            loadedTiles.Remove(tileToRemove);
        }
    }
}
