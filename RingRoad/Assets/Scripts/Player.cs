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

    

    private void ResetScorePoint()
    {
        scorePoint = 0;
    }
        
}
