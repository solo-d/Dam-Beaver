using UnityEngine;

public class DropOff_Object : MonoBehaviour
{
    public Transform playerTransform;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("damLog"))
        {
            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;
 
        }
    }
}
