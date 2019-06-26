using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    public Text scoreText;

    public GameObject gameOverPanel;
    public GameObject startUI;
    public GameObject gameOverText;

    public Text highScoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.getScore().ToString();
    }

    public void GameStart()
    {
        startUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        gameOverPanel.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
