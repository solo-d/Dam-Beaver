using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform playerTransform;
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("damLog-Final") || collision.gameObject.name == ("Mud"))
        {
            collision.gameObject.transform.parent = playerTransform.transform ;
        }
    }
}