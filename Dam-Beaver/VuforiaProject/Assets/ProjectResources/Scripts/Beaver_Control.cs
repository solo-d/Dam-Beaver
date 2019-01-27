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
        var rigibody = GetComponent<Rigidbody>();

        var x = joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 25f;
        var y = joystick.Vertical * 10f + Input.GetAxis("Vertical") * 25f;
        var z = 0f;

        transform.Translate(x *  Time.deltaTime, z, y * Time.deltaTime);
    }
}
