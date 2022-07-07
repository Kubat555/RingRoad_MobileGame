using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float yFrom;
    public float yTo;

    public float spawnTime;
    public float spawnObjTime;

    public GameObject[] spawnObj;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            GameObject a = Instantiate<GameObject>(spawnObj[Random.Range(0, spawnObj.Length)]);
            a.transform.position = new Vector3(-5, Random.Range(yFrom, yTo), 0);
            LeanTween.moveX(a, 15, spawnObjTime).setOnComplete(() =>
            {
                Destroy(a);
            });
        }
    }
}
