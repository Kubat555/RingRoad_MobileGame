using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float scorePoint;
    // Start is called before the first frame update
    [SerializeField] GameObject particle;
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
        if (collider2D.CompareTag("Enemy"))
        {
            particle.SetActive(gameObject);
            Destroy(gameObject);
        }
    }
    
    private void ResetScorePoint()
    {
        scorePoint = 0;
    }
}
