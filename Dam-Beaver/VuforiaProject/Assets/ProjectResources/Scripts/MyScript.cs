using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;
    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigibody = GetComponent<Rigidbody>();
        rigibody.velocity = new Vector3(joystick.Horizontal *100+Input.GetAxis("Horizontal")*100f, rigibody.velocity.y, joystick.Vertical * 100f+ Input.GetAxis("Vertical")*100f);

        if (!jump && (joybutton.Pressed|| Input.GetButton("Fire2"))) {
            jump = true;
            rigibody.velocity += Vector3.up * 100f;
        }
        if (jump && (joybutton.Pressed || Input.GetButton("Fire2"))) {
            jump = false;
        }

    }
}
