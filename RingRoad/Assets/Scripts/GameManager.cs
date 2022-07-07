using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float time;

    // Start is called before the first frame update
    private void Start()
    {
        timeText.text = time.ToString("F2");
        GlobalEventManager.OnCoinPicked.AddListener(RefreshScorePoint);
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");
    }

    private void RefreshScorePoint()
    {
        scoreText.text = Player.scorePoint.ToString();
    }
}
