using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public int speed = 5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Vertical
        if (transform.position.y > -32.6) {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }
        if (transform.position.y < 32.3) {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }


        // Horizontal
        if (transform.position.x > -32.4) {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }
        if (transform.position.x < 32.8) {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }

	}
}
