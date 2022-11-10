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

    [SerializeField] private float enemyStartSpeed;

    public static GameManager instance;

    private float time;

    [HideInInspector]
    public float currentTime {get{return time;}}
    public static bool inGame = false;
    private float maxTime;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 120;
        maxTime = PlayerPrefs.GetFloat("MaxTime");

        timeMaxText.text = "Best time : " + maxTime.ToString("F2");
        coinsMaxText.text = "Overall coins : " + PlayerPrefs.GetFloat("MaxScore").ToString();
        timeText.text = time.ToString("F2");

        GlobalEventManager.OnCoinPicked.AddListener(RefreshScorePoint);
        GlobalEventManager.LoseEvent.AddListener(Lose);
        Spawner.instance.ChangeSpeed(enemyStartSpeed);
    }

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Update()
    {
        if (inGame)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("F2");
            if(time >= 10 && time < 11){
                Spawner.instance.ChangeSpeed(7);
            }
            if(time >= 20 && time < 21){
                Spawner.instance.ChangeSpeed(10);
            }
            if(time >= 40 && time < 41){
                Spawner.instance.ChangeSpeed(12);
            }
            if(time >= 50 && time < 51){
                Spawner.instance.ChangeSpeed(14);
            }
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
        Spawner.instance.ChangeSpeed(enemyStartSpeed);
        GlobalEventManager.ResetPoint.Invoke();
        Spawner.instance.StartSpawn();
        particle.SetActive(false);
        RefreshScorePoint();
    }

    public void INGAME(bool a)
    {
        inGame = a;
    }
}
