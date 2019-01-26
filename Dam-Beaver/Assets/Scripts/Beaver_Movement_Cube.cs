using UnityEngine;

public class Beaver_Movement_Cube : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        moveSpeed = 100;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
