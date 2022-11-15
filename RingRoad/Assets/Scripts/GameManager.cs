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
    bool playerLose = false;

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
            if(time >= 20 && time < 21){
                Spawner.instance.ChangeSpeed(5);
                Spawner.instance.destroyObjTime = 8;
                Spawner.instance.startSpawnTime = 4;
            }
            if(time >= 40 && time < 41){
                Spawner.instance.ChangeSpeed(7);
            }
            if(time >= 60 && time < 61){
                Spawner.instance.ChangeSpeed(10);
                Spawner.instance.destroyObjTime = 5;
                Spawner.instance.startSpawnTime = 2f;
            }
            if(time >= 88 && time < 89){
                Spawner.instance.ChangeSpeed(12);
            }
            if(time >= 100 && time < 101){
                Spawner.instance.ChangeSpeed(14);
                Spawner.instance.destroyObjTime = 3;
            }
        }
       
    }

    private void RefreshScorePoint()
    {
        scoreText.text = Player.scorePoint.ToString();
    }

    void Lose()
    {
        playerLose = true;
        GlobalEventManager.onDestroyEnemy.Invoke();
        if(maxTime < time)
        {
            maxTime = time;
            PlayerPrefs.SetFloat("MaxTime", maxTime);
            timeMaxText.text = "Best time : " + maxTime.ToString("F2");
        }
        coinsMaxText.text = "Overall coins : " + PlayerPrefs.GetFloat("MaxScore").ToString();
        restartButton.GetComponent<Animator>().SetBool("Hide", false);
        timeMaxText.GetComponent<Animator>().SetBool("Hide", false);
        coinsMaxText.GetComponent<Animator>().SetBool("Hide", false);
    }

    public void Restart()
    {
        restartButton.GetComponent<Animator>().SetBool("Hide", true);
        timeMaxText.GetComponent<Animator>().SetBool("Hide", true);
        coinsMaxText.GetComponent<Animator>().SetBool("Hide", true);
        playerLose = false;
        player.SetActive(true);
        spawnerObstacle.SetActive(true);
        inGame = true;
        time = 0;
        Spawner.instance.ChangeSpeed(enemyStartSpeed);
        Spawner.instance.destroyObjTime = 12;
        Spawner.instance.startSpawnTime = 6;
        GlobalEventManager.ResetPoint.Invoke();
        Spawner.instance.StartSpawn();
        particle.SetActive(false);
        RefreshScorePoint();
    }

    public void INGAME(bool a)
    {
        inGame = a;
    }

    public void BackToMenu(){
        GlobalEventManager.onDestroyEnemy.Invoke();
        Time.timeScale = 1f;
        print("Time is continue");
        GameManager.inGame = false;
        spawnerObstacle.SetActive(false);
        restartButton.GetComponent<Animator>().SetBool("Hide", true);
    }

    public void GamePause(){
        Time.timeScale = 0;
        print("Time is paused");
        inGame = false;
    }
    public void GameContinue(){

        Time.timeScale = 1f;
        print("Time is continue");
        if(!playerLose)
            inGame = true;
    }
}
