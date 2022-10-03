using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI oldScoreText;
    [SerializeField] private bool isStarted;

    //[SerializeField] private PlayerController playerController;
    public float score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        score = 0f;
        isStarted = false;
        oldScoreText.enabled = false;
    }

    private void Update()
    {
        IsGameStart();
    }

    private void ChangeScore()
    {
        var tempscore = Time.timeScale * 0.1f;
        score += tempscore;
        scoreText.text = "Score:" + (int) score;
    }

    private void IsGameStart()
    {
        isStarted = GameManager.Instace.isStart;
        if (isStarted)
            ChangeScore();
    }

    public void SetScoreZero()
    {
        oldScoreText.text = "Old Score: " + (int)score;
        oldScoreText.enabled = true;
        scoreText.text = "Score: ";
        score = 0f;
    }
}