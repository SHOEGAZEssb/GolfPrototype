using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapObserver : MonoBehaviour
{
  [SerializeField]
  private Tilemap map;

  [SerializeField]
  private List<TileData> tileDataList;

  private Dictionary<TileBase, TileData> dataFromTiles;

  // Start is called before the first frame update
  void Start()
  {
    dataFromTiles = new Dictionary<TileBase, TileData>();

    foreach (TileData tileData in tileDataList)
    {
      foreach(var tile in tileData.tiles)
      {
        dataFromTiles.Add(tile, tileData);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    //if (Input.GetMouseButton(0))
    //{
    //  Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //  Vector3Int gridPos = map.WorldToCell(mousePos);

    //  TileBase clickedTile = map.GetTile(gridPos);
    //  Debug.Log("Drag: " + dataFromTiles[clickedTile].drag);
    //}
  }

  public float GetTileDrag(Vector2 worldPos)
  {
    Vector3Int gridPos = map.WorldToCell(worldPos);
    TileBase tile = map.GetTile(gridPos);
    if (tile == null)
      return 1;
    return dataFromTiles[tile].drag;
  }
}
