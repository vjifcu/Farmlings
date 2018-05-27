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
    public Tools heldTool = Tools.None;
    public StrikeLocation strikeLocation;
    public GameObject itemObj;
    public Sprite[] toolSprites;
    public SpriteRenderer renderer;

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
        if (newTool == Tools.None)
            itemObj.SetActive(false);
        else
        {
            print((int)newTool);
            renderer.sprite = toolSprites[(int)newTool];
            itemObj.SetActive(true);
        }
    }

    void Use()
    {
        strikeLocation.strikeWithTool();
    }

}
