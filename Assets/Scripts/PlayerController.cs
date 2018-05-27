using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;

    public float verticalVelocity;
    public float horizontalVelocity;

    public float accel;
    public float deccel = 0.9f;
    public float topSpeed = 3f;

    public GameObject facingObj;
    public float rotation = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        verticalVelocity += Input.GetAxis("Vertical") * accel;
        horizontalVelocity += Input.GetAxis("Horizontal") * accel;

	}

    void FixedUpdate()
    {
        Vector2 finalSpeed = new Vector2(horizontalVelocity, verticalVelocity);
        if (finalSpeed.magnitude > topSpeed)
            finalSpeed = finalSpeed.normalized * topSpeed;

        if (finalSpeed.magnitude > 0.1)
        {
            rotation = Vector2.Angle(Vector2.right, finalSpeed);
            if (verticalVelocity < 0)
            {
                rotation = 360 - rotation;
            }
            facingObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }


        horizontalVelocity = finalSpeed.x;
        verticalVelocity = finalSpeed.y;
        //rb.MovePosition(new Vector2(rb.position.x + horizontalVelocity, rb.position.y + verticalVelocity));
        rb.velocity = finalSpeed;

        horizontalVelocity *= deccel;
        verticalVelocity *= deccel;

        if ((finalSpeed * deccel).magnitude <= 0.01f)
        {
            horizontalVelocity = 0;
            verticalVelocity = 0;
        }
    }

    public void Disable()
    {
        rb.velocity = Vector2.zero;
        horizontalVelocity = 0f;
        verticalVelocity = 0f;
        enabled = false;
    }


}
