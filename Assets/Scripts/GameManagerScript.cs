using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    public GameObject platformGreen;
    private int platformCount = 10;
    public GameObject panel;
    public Transform camera;
    public float score;
    public TextMeshProUGUI highScoreText;
    private float highScore;


    void Start()
    {
        LoadHighScore();
        SetHighScoreText();
        panel.SetActive(false);
        Vector3 spawnPos = new Vector3();

        for (int i = 0; i <  platformCount; i++)
        {
            spawnPos.x = Random.Range(-2.5f, 2.5f);
            spawnPos.y += Random.Range(0.0f, 2f);
            Instantiate(platformGreen, spawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        score = Mathf.Max(camera.position.y, score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
            SetHighScoreText();
        }
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
                spawnPos.y = camera.transform.position.y + 5 + Random.Range(0.2f, 3f);
                platform.transform.position = spawnPos;
            }
        }
    }

    public void GameOver()
    {

        panel.SetActive(true);  
        panel.GetComponent<Animator>().Play("PanelAnim");
        Debug.Log("Game Over");
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
    void SetHighScoreText()
    {
        highScoreText.text = "Best : " + highScore.ToString();
    }
}
