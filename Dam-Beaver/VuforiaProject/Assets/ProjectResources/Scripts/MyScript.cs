using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float joystick_Horizontal_Sensitivity = 25f;
    public float joystick_Vertical_Sensitivity=25f;

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

        var x = joystick.Horizontal * 25f + Input.GetAxis("Horizontal") * 100f;
        var y = joystick.Vertical * 25f + Input.GetAxis("Vertical") * 100f;
        var z = 0f;

        transform.Translate(x *  Time.deltaTime, z, y * Time.deltaTime);
    }
}
