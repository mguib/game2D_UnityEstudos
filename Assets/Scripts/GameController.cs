using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    private int total;
    public static GameController instance;
    public GameObject gameOver;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        total = PlayerPrefs.GetInt("score");

        //Debug.Log(PlayerPrefs.GetInt("score"));
        
    }

     void Update() {
        scoreText.text = total.ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = total.ToString();

        total++;

        PlayerPrefs.SetInt("score", total);
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
