using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void Awake() {
        GlobalEventManager.onDestroyEnemy.AddListener(DestroyMe);
    }


    void DestroyMe(){
        print("destroy");
        Destroy(gameObject);
    }


}
