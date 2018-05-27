using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalObjects : MonoBehaviour {

    public static GlobalObjects Instance;
    public Tilemap FarmTilemap;
    public GameObject farmplot;
    public Transform farmplots;

    void Awake()
    {
        Instance = this;
        List<FarmTile> tiles = new List<FarmTile>();



        foreach (var pos in FarmTilemap.cellBounds.allPositionsWithin)
        {
            var curTile = FarmTilemap.GetTile<FarmTile>(pos);
            if (curTile == null)
                continue;

            curTile.cropObj = MakeFarmPlot(pos);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public CropObject MakeFarmPlot(Vector3 position)
    {
        var plot = Instantiate(farmplot, new Vector3(position.x+0.5f, position.y+0.5f, 0), new Quaternion(), farmplots);
        return plot.GetComponent<CropObject>();

    }

}
