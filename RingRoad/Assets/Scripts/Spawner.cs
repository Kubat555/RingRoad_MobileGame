using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public float yFrom;
    public float yTo;

    public float startSpawnTime;
    public float destroyObjTime;
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
        yield return new WaitForSeconds(1);
        while (true)
        {
            
            GameObject a = Instantiate<GameObject>(spawnObj[Random.Range(0, spawnObj.Length)]);
            a.transform.position = new Vector3(-7, Random.Range(yFrom, yTo), 0);
            LeanTween.moveX(a, objSpeed, destroyObjTime).setOnComplete(() =>
            {
                Destroy(a);
            });
            yield return new WaitForSeconds(startSpawnTime);
        }
    }
}
