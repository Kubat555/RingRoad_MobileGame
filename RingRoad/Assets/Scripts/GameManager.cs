using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI timeMaxText;
    [SerializeField] private TextMeshProUGUI coinsMaxText;

    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnerObstacle;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject inGamePanel;

    [SerializeField] private GameObject particle;

    private float time;
    public static bool inGame = true;
    private float maxTime;

    // Start is called before the first frame update
    private void Start()
    {
        maxTime = PlayerPrefs.GetFloat("MaxTime");

        timeMaxText.text = "Best time : " + maxTime.ToString("F2");
        coinsMaxText.text = "Overall coins : " + PlayerPrefs.GetFloat("MaxScore").ToString();
        timeText.text = time.ToString("F2");

        GlobalEventManager.OnCoinPicked.AddListener(RefreshScorePoint);
        GlobalEventManager.LoseEvent.AddListener(Lose);
    }

    private void Update()
    {
        if (inGame)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("F2");
        }
       
    }

    private void RefreshScorePoint()
    {
        scoreText.text = Player.scorePoint.ToString();
    }

    void Lose()
    {
        if(maxTime < time)
        {
            maxTime = time;
            PlayerPrefs.SetFloat("MaxTime", maxTime);
            timeMaxText.text = "Best time : " + maxTime.ToString("F2");
        }
        restartButton.GetComponent<Animator>().SetTrigger("Start");
        coinsMaxText.text = "Overall coins : " + PlayerPrefs.GetFloat("MaxScore").ToString();
    }

    public void Restart()
    {
        player.SetActive(true);
        spawnerObstacle.SetActive(true);
        inGame = true;
        time = 0;
        GlobalEventManager.ResetPoint.Invoke();
        Spawner.instance.StartSpawn();
        particle.SetActive(false);
        RefreshScorePoint();
    }
}
