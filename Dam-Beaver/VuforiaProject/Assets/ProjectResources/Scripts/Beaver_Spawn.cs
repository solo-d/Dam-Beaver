using UnityEngine;

public class Beaver_Spawn : MonoBehaviour
{
    public GameObject beaver_Prefab_gameObject;

    private void Start()
    {
        Invoke("spawn", 2f);
    }

    void spawn() {
        Instantiate(beaver_Prefab_gameObject, transform.position, Quaternion.identity);
    }
}
