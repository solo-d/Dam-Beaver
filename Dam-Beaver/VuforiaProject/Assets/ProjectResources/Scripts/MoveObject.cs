using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform playerTransform;
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("damLog"))
        {
            collision.gameObject.transform.parent = playerTransform.transform ;
        }
    }
}