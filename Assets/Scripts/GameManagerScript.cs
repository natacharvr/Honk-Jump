using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    public GameObject platformGreen;
    private int platformCount = 10;
    public Transform camera;
    public float score;
    public TextMeshProUGUI scoreText;
    private float highScore;
    private float maxHeight;

    // game over objects
    public GameObject panel;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        SetScoreText();
        panel.SetActive(false);
        Vector3 spawnPos = new Vector3(0, -1, 0);

        for (int i = 0; i <  platformCount; i++)
        {
            spawnPos.x = Random.Range(-2.5f, 2.5f);
            spawnPos.y += Random.Range(0.0f, 2f);
            maxHeight = spawnPos.y;
            Instantiate(platformGreen, spawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        score = Mathf.Max(camera.position.y, score);
        SetScoreText();
    }

    void FixedUpdate()
    {
        float bottom = camera.position.y - 5;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in platforms)
        {
            if (platform.transform.position.y < bottom)
            {
                Vector3 spawnPos = new Vector3();
                spawnPos.x = Random.Range(-2.5f, 2.5f);
                spawnPos.y = Mathf.Max(maxHeight + Random.Range(0.3f, 2f), camera.transform.position.y + 5);
                maxHeight = spawnPos.y;
                platform.transform.position = spawnPos;
            }
        }
    }

    public void GameOver()
    {

        panel.SetActive(true);  
        panel.GetComponent<Animator>().Play("PanelAnim");

        LoadHighScore();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        //Debug.Log("Game Over");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetFloat("highScore", -1);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString("F0");
        finalScoreText.text = "your score: " + score.ToString("F0");
        highScoreText.text = "your high score: " + highScore.ToString("F0");
    }
}
