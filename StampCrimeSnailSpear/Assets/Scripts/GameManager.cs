using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject events;
    public GameObject canvas;
    public static GameManager Instance { get; private set; }
    public GameObject startButton;
    public TextMeshProUGUI startButtonTextBox;
    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI titleTextBox;
    private int score;
    private int stampCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(canvas);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        stampCount = 0;
        scoreTextBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementStampCount(int changeInStamps)
    {
        stampCount += changeInStamps;
    }

    public int GetStampCount()
    {
        return stampCount;
    }

    public void IncrementScore(int changeBy)
    {
        score += changeBy;
        scoreTextBox.text = "Stamps Stolen: " + score;
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        titleTextBox.gameObject.SetActive(false);
        scoreTextBox.text = "Stamps Stolen: " + score;
        scoreTextBox.gameObject.SetActive(true);
        SceneManager.LoadScene("Main_Game");
    }

    public void GameOver()
    {
        StopAllCoroutines();
        stampCount = 0;
        score = 0;
        scoreTextBox.gameObject.SetActive(false);
        startButton.SetActive(true);
        startButtonTextBox.SetText("Try again?");
        SceneManager.LoadScene("Game_Over");
    }
}
