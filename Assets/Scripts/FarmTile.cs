using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "FarmTile")]
public class FarmTile : TileBase {

    public Sprite sprite;
    public CropObject cropObj;
    public Vector3 location;
    public bool setLocation = false;
    public static int globalID = 0;
    public int ID = 0;

    public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
    {
        if (go != null)
        {
            go.transform.rotation = Random.rotation;
        }

        ID = globalID++;

        return true;
    }

    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        tilemap.RefreshTile(location);
    }

    // This determines which sprite is used based on the RoadTiles that are adjacent to it and rotates it to fit the other tiles.
    // As the rotation is determined by the RoadTile, the TileFlags.OverrideTransform is set for the tile.
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
            tileData.sprite = sprite;
            tileData.color = Color.white;
            //tileData.colliderType = ColliderType.None;
    }

}
