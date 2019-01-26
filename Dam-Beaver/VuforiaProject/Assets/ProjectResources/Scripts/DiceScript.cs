using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 dice_velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		dice_velocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space)) {
			TextDiceNumberShow.dice_number = 0;
			float x = Random.Range (0, 500);
			float y = Random.Range (0, 500);
			float z = Random.Range (0, 500);
			transform.position = new Vector3 (0, 2, 0);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 500);
			rb.AddTorque (x, y, z);
		}
	}
}
