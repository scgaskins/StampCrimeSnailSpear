using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI textBox;
    private int score;
    private int stampCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        textBox.text = "Stamps Stolen: " + score;
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
        textBox.text = "Stamps Stolen: " + score;
    }
}
