using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNetwork : MonoBehaviour {
    Rigidbody2D rb2d;
    public float v;
    public float h;
    public bool isMoving;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isMoving = false;
	}
	
	// Update is called once per frame
	public void Update () {
        
        transform.Rotate(0,0, -h * 100f * Time.deltaTime);
      
        if ( v > 0)
        {
            rb2d.AddForce(transform.up * 5f * v);
            //Network.Move(v,h);
            isMoving = true;
            Debug.Log("Key Down");

        }
        else
        {
            if (isMoving) { 
                rb2d.velocity = Vector2.zero;
                v = 0;
                //Network.Move(v, h);
                isMoving = false;
                Debug.Log("Key Up");
            }
           
        }

        //Network.Move(v,h);

	}
}