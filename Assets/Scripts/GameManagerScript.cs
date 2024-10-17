using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    // platflorms
    public GameObject platformGreen;
    private int platformCount = 10;
    public GameObject platformBlue;
    public GameObject platformBrown;


    // black hole
    public GameObject blackHole;

    public Transform camera;
    // score
    public float score;
    public TextMeshProUGUI scoreText;
    private float highScore;
    private float maxHeight;

    // game over objects
    public GameObject panel;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;

    // spawn conidition
    float yPosCondition = 0.0f;

    void Start()
    {
        SetScoreText();
        panel.SetActive(false);
        Vector3 spawnPos = new Vector3(0, -1, 0);

        for (int i = 0; i <  platformCount; i++)
        {
            spawnPos.x = Random.Range(-2.5f, 2.5f);
            spawnPos.y += Random.Range(0.3f, 1.5f);
            maxHeight = spawnPos.y;
            Instantiate(platformGreen, spawnPos, Quaternion.identity);
        }

        Vector3 spawnPosBlackHole = new Vector3();
        spawnPosBlackHole.x = Random.Range(-2.5f, 2.5f);
        spawnPosBlackHole.y = Random.Range(5f, 10f);
        Instantiate(blackHole, spawnPosBlackHole, Quaternion.identity);
    }

    void Update()
    {
        score = Mathf.Max(camera.position.y, score);
        SetScoreText();

        if (camera.position.y > yPosCondition)
        {
            spawnGreen();
            spawnBlue();
            spawnBrown();
            spawnBlackHole();
        }
    }

    void FixedUpdate()
    {
        float bottom = camera.position.y - 5;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        GameObject[] blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");

        foreach (GameObject platform in platforms)
        {
            if (platform.transform.position.y < bottom)
            {
                Destroy(platform);
            }
        }


        foreach (GameObject blackHole in blackHoles)
        {
            if (blackHole.transform.position.y < bottom)
            {
                Destroy(blackHole);
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("active une fois Game Over");
        StartCoroutine(camera.GetComponent<CameraScript>().moveCameraDown());
        panel.SetActive(true);  
        panel.GetComponent<Animator>().Play("PanelAnim");

        LoadHighScore();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
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


    Vector3 spawnPos(bool updateHeight = true)
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = Random.Range(-2.5f, 2.5f);
        spawnPos.y = Mathf.Max(maxHeight + Random.Range(0.4f, 1.5f), camera.transform.position.y + 5);

        yPosCondition = yPosCondition + spawnPos.y - maxHeight;
        if (updateHeight) {
            maxHeight = spawnPos.y;
        }
        return spawnPos;
    }

    void spawnGreen(bool force = false)
    {
        float spawnProb = Random.Range(0.0f, 1.0f);
        if (force) {
            spawnProb = 1.0f;
            Debug.Log("force");
        }
        if (spawnProb > 0.1)
        {
            Instantiate(platformGreen, spawnPos(), Quaternion.identity);
        }
    }

    void spawnBlue()
    {
        float spawnProb = Random.Range(0.0f, 1.0f);
        if (spawnProb > 0.5)
        {
            Instantiate(platformBlue, spawnPos(), Quaternion.identity);
        }
    }

    void spawnBlackHole()
    {
        float spawnProb = Random.Range(0.0f, 1.0f);
        if (spawnProb > 0.9)
        {
            Instantiate(blackHole, spawnPos(false), Quaternion.identity);
        }
    }

    void spawnBrown()
    {
        float spawnProb = Random.Range(0.0f, 1.0f);
        if (spawnProb > 0.5)
        {
            Instantiate(platformBrown, spawnPos(false), Quaternion.identity);
        }
    }

}
