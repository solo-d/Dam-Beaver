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

            CreatePrefab(playerTransform.gameObject);

        }
        else if (collision.gameObject.name == ("Mud"))
        {
            GameObject prev_parent = collision.gameObject.transform.parent.gameObject;

            prev_parent.transform.Translate(100f * Time.deltaTime, 0f, 100f * Time.deltaTime);

            collision.gameObject.transform.parent = playerTransform.transform;
        }
    }

    static void CreatePrefab(GameObject preFab)
    {
        // Ref link   https://answers.unity.com/questions/551934/instantiating-using-a-string-for-prefab-name.html

        var planet = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Stump.prefab", typeof(GameObject));

        string charName = "stump";
            
            // duplicate
            GameObject newInstance = Instantiate(preFab);
            newInstance.name = charName;

            // now replace the prefab
            string prefabPath = "Assets/Prefabs/" + charName + ".prefab";
            var existingPrefab = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
            if (existingPrefab != null)
            {
                PrefabUtility.ReplacePrefab(newInstance, planet, ReplacePrefabOptions.ReplaceNameBased);
            }
            else
            {
                PrefabUtility.CreatePrefab("Assets/Prefabs/Stump.prefab", newInstance);
            }

            // delete dupe
            DestroyImmediate(newInstance);

            Debug.Log("Prefab'd " + charName + "! \"" + prefabPath + "\"");
    }

}
