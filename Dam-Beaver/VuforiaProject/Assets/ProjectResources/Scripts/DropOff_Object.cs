using UnityEditor;
using UnityEngine;

public class DropOff_Object : MonoBehaviour
{
    public Transform playerTransform;
    private Quaternion rotation;
    private Vector3 position;
    private GameObject currentGameObject;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("damLog-Final"))
        {

            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;
            Debug.Log("Calling INVOKED");
            Invoke("ReplaceTree", 2f);

            SwapPrefabs(playerTransform.gameObject, "Assets/Prefabs/Final/Stump.prefab");
        }
        else if (collision.gameObject.name == ("Mud"))
        {
            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;
        }
    }

    void ReplaceTree() {
        Debug.Log("I WAS INVOKED");
        SwapPrefabs(playerTransform.gameObject, "Assets/Prefabs/Final/tree2-Final.prefab");

    }

    /// <summary>Swaps the desired oldGameObject for a newPrefab.</summary>
    /// <param name="oldGameObject">The old game object.</param>
    void SwapPrefabs(GameObject oldGameObject, string newPrefab)
    {
        Debug.Log("Swapped INVOKED");
        // Determine the rotation and position values of the old game object.
        // Replace rotation with Quaternion.identity if you do not wish to keep rotation.
        rotation = oldGameObject.transform.rotation;
        position = oldGameObject.transform.position;

        // Instantiate the new game object at the old game objects position and rotation.
        //GameObject newGameObject = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Stump.prefab", typeof(GameObject));

        Object newPreFab = AssetDatabase.LoadAssetAtPath(newPrefab, typeof(GameObject));
        GameObject newGameObject = Instantiate(newPreFab, position, rotation) as GameObject;

        // If the old game object has a valid parent transform,
        // (You can remove this entire if statement if you do not wish to ensure your
        // new game object does not keep the parent of the old game object.
        if (oldGameObject.transform.parent != null)
        {
            // Set the new game object parent as the old game objects parent.
            newGameObject.transform.SetParent(oldGameObject.transform.parent);
            currentGameObject = newGameObject;
        }

        // Destroy the old game object, immediately, so it takes effect in the editor.
        Destroy(oldGameObject);
    }

}
