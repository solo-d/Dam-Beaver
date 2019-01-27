using UnityEngine;

public class Tree_Spawn : MonoBehaviour
{
    public GameObject Tree_Prefab_gameObject;

    private void Start()
    {
        Invoke("spawn", 2f);
    }

    void spawn()
    {
        Instantiate(Tree_Prefab_gameObject, transform.position, Quaternion.identity);
    }
}