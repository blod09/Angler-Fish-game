using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[System.Serializable]
public class SpawnableObject {

    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    [Range (0.0f, 1.0f)]
    public float spawnRatio;
}


public class Spawner : MonoBehaviour {


    Vector3 offsetFromCamera;

    [SerializeField]
    SpawnableObject[] spawnList;
    [SerializeField]
    float spawnRateMin;
    [SerializeField]
    float spawnRateMax;
    Camera cam;

    private void Awake ()
    {
        cam = Camera.main;
        offsetFromCamera = transform.position - cam.transform.position;

        StartCoroutine (DoSpawn ());
    }

    private void Update ()
    {
        transform.position =  cam.transform.position + offsetFromCamera;
    }

    

    private GameObject GetRandomSpawn ()
    {
        float totalSpawnRatio = 0.0f;
        foreach (SpawnableObject s in spawnList)
        {
            totalSpawnRatio += s.spawnRatio;
        }

        float r = Random.Range(0.0f, totalSpawnRatio);
        float counter = 0.0f;

        foreach (SpawnableObject s in spawnList)
        {
            if (r < s.spawnRatio + counter)
                return s.prefab;
            else
                counter += s.spawnRatio;
        }

        return null;

    }

    private void Spawn (Vector2 position, GameObject prefab)
    {
        Instantiate (prefab, position, Quaternion.identity);
    }

    private IEnumerator DoSpawn ()
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range (spawnRateMin, spawnRateMax));

            if (spawnList.Length > 0) {
                GameObject go = GetRandomSpawn();
                if (go != null) {
                    Spawn (transform.position, go);
                    Debug.Log ("Spawned " + go.name);
                } else
                {
                    Debug.Log ("Failed to spawn");
                }
            } else
            {
                Debug.Log ("Spawn list is empty");
            }

        }
    }

    #if UNITY_EDITOR

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere (transform.position, 1.0f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (transform.position + Vector3.up * .5f + Vector3.right * .5f, transform.position + Vector3.down * .5f + Vector3.left * .5f);
        Gizmos.DrawLine (transform.position + Vector3.up * .5f + Vector3.left * .5f, transform.position + Vector3.down * .5f + Vector3.right * .5f);
}
#endif
}
