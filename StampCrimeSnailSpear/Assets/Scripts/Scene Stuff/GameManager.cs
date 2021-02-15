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
    public GameObject instructionButton;
    public TextMeshProUGUI instructionButtonText;
    private bool showingInstructions;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI titleTextBox;
    public TextMeshProUGUI finalScoreTextBox;

    public GameObject dialogBox;
    public GameObject dialogText;

    private Coroutine dialogCo;

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
        finalScoreTextBox.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);
        showingInstructions = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
    }
    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCo);
    }
    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.1f);
        }
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
        instructionButton.SetActive(false);
        titleTextBox.gameObject.SetActive(false);
        finalScoreTextBox.gameObject.SetActive(false);
        stampCount = 0;
        score = 0;
        scoreTextBox.text = "Stamps Stolen: " + score;
        scoreTextBox.gameObject.SetActive(true);
        SceneManager.LoadScene("Main_Game");
    }

    public void ShowInstructions()
    {
        showingInstructions = !showingInstructions;
        if (showingInstructions)
        {
            startButton.SetActive(false);
            instructionText.gameObject.SetActive(true);
            instructionButtonText.SetText("Back to Menu");
        } else
        {
            instructionButtonText.SetText("View Instructions");
            instructionText.gameObject.SetActive(false);
            startButton.SetActive(true);
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
        dialogBox.SetActive(false);
        scoreTextBox.gameObject.SetActive(false);
        startButton.SetActive(true);
        startButtonTextBox.SetText("Try again?");
        SceneManager.LoadScene("Game_Over");
    }

    public void GoToWinScreen()
    {
        StopAllCoroutines();
        scoreTextBox.gameObject.SetActive(false);
        startButton.SetActive(true);
        startButtonTextBox.SetText("Play again?");
        titleTextBox.gameObject.SetActive(true);
        titleTextBox.SetText("You Made It!");
        finalScoreTextBox.SetText("Stamps Stolen: " + score);
        finalScoreTextBox.gameObject.SetActive(true);
        SceneManager.LoadScene("Victory_Screen");
    }
}
