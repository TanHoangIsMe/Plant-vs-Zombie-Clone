using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClickedManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject ghostObj;

    private void Awake()
    {
        ghostObj.SetActive(false); 
    }

    private void Update()
    {
        CheckCharacterPlacement();           
    }

    private void CheckCharacterPlacement()
    {
        // Change click position onscreen to world position
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Prevent spawn character on same tile
        if(CheckSpawnCondition(worldPos)) return;

        // Change world position to tile map position
        Vector3Int gridPos = tileMap.WorldToCell(worldPos);

        // Get tile name in tile map position
        TileBase clickedTile = tileMap.GetTile(gridPos);

        // Check if clicked tile can place character
        CheckTileCondition(gridPos, clickedTile);
    }

    private void CheckTileCondition(Vector3Int gridPos, TileBase clickedTile)
    {
        if (clickedTile != null && Enum.TryParse<IndustryValidTileName>(clickedTile.name.ToString(), out IndustryValidTileName result))
            SpawnCharacter(gridPos, clickedTile, (int)result);
        else
            ghostObj.SetActive(false);
    }

    private bool CheckSpawnCondition(Vector3 worldPos)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(worldPos, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
            if (hit.collider.gameObject.layer == 7)
            {
                ghostObj.SetActive(false);
                return true;
            }
        return false;
    }

    private void SpawnCharacter(Vector3Int gridPos, TileBase clickedTile, int result)
    {
        // get spawn position
        Vector3 worldPosOfTile = tileMap.CellToWorld(gridPos);
        worldPosOfTile += new Vector3(0, 0.8f, 0);
        Vector3 spawnPos = GetSpawnPos(result, worldPosOfTile);

        ghostObj.transform.position = spawnPos;
        ghostObj.SetActive(true);

        Spawn(spawnPos);
    }

    private void Spawn(Vector3 spawnPos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            ghostObj.SetActive(false);
            Instantiate(character, spawnPos, Quaternion.identity);
        }
    }

    private static Vector3 GetSpawnPos(int result, Vector3 worldPosOfTile)
    {
        return (int)result == 1 ?
                    new Vector3(worldPosOfTile.x + 0.8f, worldPosOfTile.y, 0) :
                    (int)result == 2 ?
                    worldPosOfTile :
                    (int)result == 3 ?
                    new Vector3(worldPosOfTile.x, worldPosOfTile.y + 0.8f, 0) :
                    new Vector3(worldPosOfTile.x + 0.8f, worldPosOfTile.y + 0.8f, 0);
    }
}
