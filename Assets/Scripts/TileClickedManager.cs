using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClickedManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject a;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Change click position onscreen to world position
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Change world position to tile map position
            Vector3Int gridPos = tileMap.WorldToCell(worldPos);

            // Get tile name in tile map position
            TileBase clickedTile = tileMap.GetTile(gridPos);

            // Check if clicked tile can place character
            if (Enum.TryParse<IndustryValidTileName>(clickedTile.name.ToString(), out IndustryValidTileName result))
            {
                Vector3 worldPosOfTile = tileMap.CellToWorld(gridPos);
                float updatedValueX;
                float updatedValueY;
                Vector3 spawnPos;
                if ((int)result == 0)
                {
                    updatedValueX = (float)worldPosOfTile.x + 0.8f;
                    spawnPos = new Vector3(updatedValueX, worldPosOfTile.y, 0f);
                    Instantiate(a, spawnPos, Quaternion.identity);
                }else if((int)result == 1)
                {
                    Instantiate(a, worldPosOfTile, Quaternion.identity);
                }else if((int)result == 2)
                {
                    updatedValueY = (float)worldPosOfTile.y + 0.8f;
                    spawnPos = new Vector3(worldPosOfTile.x, updatedValueY, 0f);
                    Instantiate(a, spawnPos, Quaternion.identity);
                }
                else
                {
                    updatedValueX = (float)worldPosOfTile.x + 0.8f;
                    updatedValueY = (float)worldPosOfTile.y + 0.8f;
                    spawnPos = new Vector3(updatedValueX, updatedValueY, 0f);
                    Instantiate(a, spawnPos, Quaternion.identity);
                }

            }
            else
            {
                Debug.Log($"Clicked tile '{clickedTile}' is not a valid enum.");
            }
        }
    }
}
