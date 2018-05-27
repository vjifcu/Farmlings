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
        }
    }
}
