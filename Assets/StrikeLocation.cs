using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeLocation : MonoBehaviour {

    public UseTool useTool;
    public CircleCollider2D col;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<CropObject>() != null)
        {
            coll.gameObject.GetComponent<CropObject>().Use(useTool.heldTool);
        }
        else if (coll.gameObject.GetComponent<ToolObject>() != null)
        {
            useTool.EquipTool(coll.gameObject.GetComponent<ToolObject>().tool);
        }
    }

    public void strikeWithTool()
    {
        StartCoroutine(strike());
    }

    IEnumerator strike()
    {
        col.enabled = true;
        yield return null;
        yield return null;
        col.enabled = false;
    }

}
