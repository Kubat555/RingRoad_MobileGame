using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public float yFrom;
    public float yTo;

    public float startSpawnTime;
    public float spawnObjTime;
    private float objSpeed;

    public GameObject[] spawnObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void ChangeSpeed(float speed) {
        objSpeed = speed;
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(startSpawnTime);
            GameObject a = Instantiate<GameObject>(spawnObj[Random.Range(0, spawnObj.Length)]);
            a.transform.position = new Vector3(-7, Random.Range(yFrom, yTo), 0);
            LeanTween.moveX(a, objSpeed, spawnObjTime).setOnComplete(() =>
            {
                Destroy(a);
            });
        }
    }
}
