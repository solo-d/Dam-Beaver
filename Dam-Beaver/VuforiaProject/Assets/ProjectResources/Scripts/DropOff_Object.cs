using UnityEditor;
using UnityEngine;

public class DropOff_Object : MonoBehaviour
{
    public Transform playerTransform;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("damLog-Final"))
        {

            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;

            SwapPrefabs(playerTransform.gameObject);

        }
        else if (collision.gameObject.name == ("Mud"))
        {
            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;
        }
    }

    /// <summary>Swaps the desired oldGameObject for a newPrefab.</summary>
    /// <param name="oldGameObject">The old game object.</param>
    void SwapPrefabs(GameObject oldGameObject)
    {
        // Determine the rotation and position values of the old game object.
        // Replace rotation with Quaternion.identity if you do not wish to keep rotation.
        Quaternion rotation = oldGameObject.transform.rotation;
        Vector3 position = oldGameObject.transform.position;

        // Instantiate the new game object at the old game objects position and rotation.
        //GameObject newGameObject = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Stump.prefab", typeof(GameObject));

        Object newPreFab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Final/Stump.prefab", typeof(GameObject));
        GameObject newGameObject = Instantiate(newPreFab, position, rotation) as GameObject;

        // If the old game object has a valid parent transform,
        // (You can remove this entire if statement if you do not wish to ensure your
        // new game object does not keep the parent of the old game object.
        if (oldGameObject.transform.parent != null)
        {
            // Set the new game object parent as the old game objects parent.
            newGameObject.transform.SetParent(oldGameObject.transform.parent);
        }

        // Destroy the old game object, immediately, so it takes effect in the editor.
        Destroy(oldGameObject);
    }

    //static void CreatePrefab(GameObject preFab)
    //{
    //    // Ref link   https://answers.unity.com/questions/551934/instantiating-using-a-string-for-prefab-name.html

    //    var planet = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Stump.prefab", typeof(GameObject));

    //    string charName = "stump";
            
    //        // duplicate
    //        GameObject newInstance = Instantiate(preFab);
    //        newInstance.name = charName;

    //        // now replace the prefab
    //        string prefabPath = "Assets/Prefabs/" + charName + ".prefab";
    //        var existingPrefab = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
    //        if (existingPrefab != null)
    //        {
    //            PrefabUtility.ReplacePrefab(newInstance, planet, ReplacePrefabOptions.ReplaceNameBased);
    //        }
    //        else
    //        {
    //            PrefabUtility.CreatePrefab("Assets/Prefabs/Stump.prefab", newInstance);
    //        }

    //        // delete dupe
    //        DestroyImmediate(newInstance);

    //        Debug.Log("Prefab'd " + charName + "! \"" + prefabPath + "\"");
    //}

}
