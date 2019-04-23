using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float timerCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public bool winCondition;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioSource winSource;
    public AudioSource loseSource;

    public Text scoreText;
    public Text restartText;
    public Text gameoverText;
    public Text winText;
    public Text gameText;
    public Text hardText;
    public Text timerText;

    public bool hardModeActivate;

    private bool timeAttackCheck = StaticTimeCheck.timeAttackCheck;

    private bool gameOver;
    private bool restart;
    private bool soundPLayed;
    private int score;
    private GameObject playerObj;

    private void Start()
    {
        gameOver = false;
        restart = false;
        winCondition = false;
        soundPLayed = false;
        hardModeActivate = false;
        timerText.text = "";
        hardText.text = "";
        gameoverText.text = "";
        restartText.text = "";
        winText.text = "";
        gameText.text = "";
        score = 0;
        timerCount = 31;
        playerObj = GameObject.Find("Player");
        UpdateScore();
        StartCoroutine (SpawnWaves());

        if (timeAttackCheck == false)
        {
            hardText.text = "Press SHIFT for Challenger Speed";
        }

    }

    private void Update()
    {
        if (timeAttackCheck == true && timerCount >= 0)
        {
            timerCount -= Time.deltaTime;
            timerText.text = "Time: " + (int)timerCount;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && hardModeActivate == false && timeAttackCheck == false)
        {
            hardModeActivate = true;
            hardText.text = "";
        }

        if (winCondition == true && soundPLayed == false)
        {
            winSource.Play();
            soundPLayed = true;
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Final_Base");
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'SPACEBAR' for Restart \n\nPress 'M' for Main Menu";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100 && timeAttackCheck == false)
        {
            winText.text = "You Win!";
            gameText.text = "GAME CREATED BY ROBERT CAMPOS";
            winCondition = true;
            gameOver = true;
            restart = true;
        }


        if (timerCount <= 0 && timeAttackCheck == true && gameOver == false)
        {
            winText.text = "You Win!";
            gameText.text = "GAME CREATED BY ROBERT CAMPOS";
            winCondition = true;
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        gameoverText.text = "Game Over!";
        gameOver = true;
        loseSource.Play();
    }

}
