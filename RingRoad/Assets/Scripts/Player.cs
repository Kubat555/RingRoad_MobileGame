using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float scorePoint;
    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.ResetPoint.AddListener(ResetScorePoint);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Coin"))
        {
            scorePoint++;
            GlobalEventManager.OnCoinPicked.Invoke();
            Destroy(collider2D.gameObject);
            print(scorePoint);
        }
    }
    
    private void ResetScorePoint()
    {
        scorePoint = 0;
    }
}
