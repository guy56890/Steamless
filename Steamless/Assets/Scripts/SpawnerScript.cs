using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ScavengerPrefab;
    public float ScavengerInterval = 3.5f;
    public float X_cord1 = 0f;
    public float X_cord2 = 0f;
    public float Y_cord1 = 0f;
    public float Y_cord2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(ScavengerInterval, ScavengerPrefab));
    }

    // Update is called once per frame
    IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(X_cord1,X_cord2),Random.Range(Y_cord1,Y_cord2), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
