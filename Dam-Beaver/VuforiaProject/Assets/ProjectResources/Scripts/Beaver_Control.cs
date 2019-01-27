using UnityEngine;

public class Beaver_Control : MonoBehaviour
{
    public float joystick_Horizontal_Sensitivity = 1f;
    public float joystick_Vertical_Sensitivity = 1f;

    protected Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var joy_position_x = joystick.Horizontal;
        var joy_position_y = joystick.Vertical;
        Debug.Log(joy_position_x);
        Debug.Log(joy_position_y);

        if (joy_position_x != 0 || joy_position_y != 0)
        {

            transform.LookAt(new Vector3(transform.position.x + joy_position_x, transform.position.y, transform.position.z + joy_position_y));
            transform.Translate(Vector3.forward * Time.deltaTime * 8);
        }

        //var rigibody = GetComponent<Rigidbody>();

        //var x = (joystick.Horizontal * 2f + Input.GetAxis("Horizontal"))/(float)10.0;
        //var y = 0;
        //var z = (joystick.Vertical * 2f + Input.GetAxis("Vertical"))/(float) 10.0;

        //transform.Translate(x *  Time.deltaTime, y * Time.deltaTime, z);
    }
}
