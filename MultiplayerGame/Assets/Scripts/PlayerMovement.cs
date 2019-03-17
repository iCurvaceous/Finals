using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb2d;
    bool isMoving;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isMoving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0,0, -Input.GetAxisRaw("Horizontal") * 100f * Time.deltaTime);


        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb2d.AddForce(transform.up * 5f * Input.GetAxisRaw("Vertical"));
            Network.Move(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
           
            isMoving = true;
        }
        else
        {
            if (isMoving)
            {
                rb2d.velocity = Vector2.zero;
                Network.Move(0, 0);
                isMoving = false;
                
            }
        }
        
    }
}