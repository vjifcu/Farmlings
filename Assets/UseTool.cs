using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTool : MonoBehaviour {
	


	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {

            GetComponent<PlayerController>().Disable();

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<PlayerController>().enabled = true;
        }
	}

    void Use()
    {

    }

}
