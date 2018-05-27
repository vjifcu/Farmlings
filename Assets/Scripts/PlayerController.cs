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

    public float storedXAxis;
    public float storedYAxis;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        storedXAxis = Input.GetAxis("Vertical") * accel;
        storedYAxis = Input.GetAxis("Horizontal") * accel;

        if((storedXAxis > 0.01 || storedXAxis < -0.01) || (storedYAxis > 0.01 || storedYAxis < -0.01))
        {
            myAnimator.SetBool("walking", true);
        }
	}

    void FixedUpdate()
    {
        verticalVelocity += storedXAxis;
        horizontalVelocity += storedYAxis;

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

        if ((finalSpeed * deccel).magnitude <= 0.2f)
        {
            horizontalVelocity = 0;
            verticalVelocity = 0;
            myAnimator.SetBool("walking", false);
        } else
        {
            myAnimator.SetBool("walking", true);
        }
        if(myAnimator.GetBool("walking"))
            DefinePlayerDirection(finalSpeed);
    }

    public void Disable()
    {
        rb.velocity = Vector2.zero;
        horizontalVelocity = 0f;
        verticalVelocity = 0f;
        myAnimator.SetBool("walking", false);
        enabled = false;
    }

    void DefinePlayerDirection(Vector2 input)
    {
        myAnimator.SetFloat("InputX", input.x);
        myAnimator.SetFloat("InputY", input.y);
    }

}
