using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float yFrom;
    public float yTo;

    public float startSpawnTime;
    public float spawnObjTime;

    public GameObject[] spawnObj;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(startSpawnTime);
            GameObject a = Instantiate<GameObject>(spawnObj[Random.Range(0, spawnObj.Length)]);
            a.transform.position = new Vector3(-7, Random.Range(yFrom, yTo), 0);
            LeanTween.moveX(a, 15, spawnObjTime).setOnComplete(() =>
            {
                Destroy(a);
            });
        }
    }
}
