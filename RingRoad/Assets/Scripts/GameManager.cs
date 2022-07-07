using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnCoinPicked.AddListener(RefreshScorePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RefreshScorePoint()
    {
        
    }
}
