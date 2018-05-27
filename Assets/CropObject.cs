using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Crops
{
    Tomato,
    Carrot,
    Onion,
    GreenBean,
    None
}

public class CropObject : MonoBehaviour {

    public Crops crop = Crops.None;
    public Sprite tilledSprite;
    public Sprite[] tomatoSprites;
    public Sprite[] CarrotSprites;
    public Sprite[] OnionSprites;
    public Sprite[] GreenBeanSprites;
    public SpriteRenderer renderer;
    public bool tilled = false;
    public bool planted = false;
    public bool watered = false;
    public bool wilted = false;
    public int growthStage = 0;

    public void Awake()
    {
        renderer.enabled = false;
    }

    public void Use(Tools tool)
    {
        if (tool == Tools.Hoe && !tilled)
        {
            renderer.enabled = true;
            tilled = true;
            renderer.sprite = tilledSprite;
        } else if (tool == Tools.WateringCan && tilled && !watered)
        {
            watered = true;
            renderer.color = new Color(170f/255, 170f/255, 170f/255);
        } else if (tool == Tools.Sickle && planted)
        {
            print("Used Sickle");
            planted = false;
            tilled = false;
            watered = false;
            renderer.color = Color.white;
        } else if (tool != Tools.None && tilled && !planted)
        {
            //Held tool must be seeds, by elimination.
            //The PROPER way to do this would be through bit operations with the enum, but it's CRUNCH TIME
            print("Planted seed");
            planted = true;
        }
    }
}
