using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Tools
{
    Hoe,
    WateringCan,
    Sickle,
    TomatoSeed,
    CarrotSeed,
    OnionSeed,
    GreenBeanSeed,
    None
}

public class UseTool : MonoBehaviour {

    public Transform toolTrans;
    Tilemap farmTilemap;
    public Tools heldTool = Tools.Hoe;
    public StrikeLocation strikeLocation;

    void Start()
    {
        farmTilemap = GlobalObjects.Instance.FarmTilemap;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<PlayerController>().Disable();

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Use();
            GetComponent<PlayerController>().enabled = true;
        }
	}

    public void EquipTool(Tools newTool)
    {
        heldTool = newTool;
    }

    void Use()
    {
        strikeLocation.strikeWithTool();
    }

}
