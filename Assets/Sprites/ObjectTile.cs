using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ObjectTile : Tile
{
  public override void GetTileData(Vector3Int position, ITilemap tilemap, ref UnityEngine.Tilemaps.TileData tileData)
  {
    //tileData.gameObject = ColliderToSpawn;
    base.GetTileData(position, tilemap, ref tileData);
  }
}
