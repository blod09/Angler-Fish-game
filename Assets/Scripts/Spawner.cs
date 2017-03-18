using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private float spawnX;
    private float spawnY;

    [SerializeField]
    private GameObject foodPrefab;
    [SerializeField]
    private GameObject enemyPrefab;

    Camera cam;

    private void Start ()
    {
        cam = Camera.main;
        StartCoroutine (FoodSpawner ());
        StartCoroutine (EnemySpawner ());
    }

    private Vector2 GetRandomPosition ()
    {
        spawnX = cam.ViewportToWorldPoint (new Vector3(1.0f, 0.0f, -cam.transform.position.z)).x + 10.0f;
        spawnY = Random.Range (cam.ViewportToWorldPoint (new Vector3 (0.0f, 0.0f, -cam.transform.position.z)).y, cam.ViewportToWorldPoint (new Vector3 (0.0f, 1.0f, -cam.transform.position.z)).y);
        return new Vector2 (spawnX, spawnY);
    }

    private void Spawn (Vector2 position, GameObject prefab)
    {
        Instantiate (prefab, position, Quaternion.identity);
        //Debug.Log ("Spawned fish at: " + position.ToString ());
    }

    private IEnumerator FoodSpawner ()
    {
        while (true)
        {
            Spawn (GetRandomPosition (), foodPrefab);
            yield return new WaitForSeconds (Random.Range(.5f, 2.0f));
        }
    }

    private IEnumerator EnemySpawner ()
    {
        while (true)
        {
            Spawn (GetRandomPosition (), enemyPrefab);
            yield return new WaitForSeconds (Random.Range (1.5f, 3.0f));
        }
    }
}
