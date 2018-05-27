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
    public Sprite[][] cropSprites;
    public SpriteRenderer renderer;
    public bool tilled = false;
    public bool planted = false;
    public bool watered = false;
    public bool wilted = false;
    public int growthStage = 0;

    public SpriteRenderer cropRenderer;

    public void Awake()
    {
        renderer.enabled = false;
        //Ugly AF but time is running out D:
        cropSprites[0] = tomatoSprites;
        cropSprites[1] = CarrotSprites;
        cropSprites[2] = OnionSprites;
        cropSprites[3] = GreenBeanSprites;
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
            cropRenderer.sprite = null;
        } else if (tilled && (tool == Tools.TomatoSeed || tool == Tools.CarrotSeed || tool == Tools.OnionSeed || tool == Tools.GreenBeanSeed))
        {
            //The PROPER way to do this would be through bit operations with the enum, but it's CRUNCH TIME
            print("Planted " + ((int)tool - (int)Tools.TomatoSeed));
            cropRenderer.sprite = cropSprites[(int)tool - (int)Tools.TomatoSeed][0];
            planted = true;
        }
    }
}
