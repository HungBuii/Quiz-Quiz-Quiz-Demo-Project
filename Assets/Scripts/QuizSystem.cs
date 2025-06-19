using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizSystem : MonoBehaviour
{
    [Header("Quizzes")]
    [SerializeField] private List<QuizSO> quizzes = new List<QuizSO>();
    private int currentQuiz = 0;
    public bool completeQuiz = false;

    [Header("Question")]
    [SerializeField] private TextMeshProUGUI question;

    [Header("Button Answer")]
    [SerializeField] private List<Button> buttons = new List<Button>();
    private int correctAnswer;
    private bool canAnswered;

    [Header("Sprite Button")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Time")]
    [SerializeField] private Image timer;
    TimerSystem timerSystem;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    ScoreSystem scoreSystem;

    [Header("Slider")]
    [SerializeField] private Slider sliderNumberQuiz;

    void Awake()
    {
        timerSystem = FindObjectOfType<TimerSystem>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        sliderNumberQuiz.maxValue = quizzes.Count;
        sliderNumberQuiz.value = 0; 
    }

    private void Start()
    {
        scoreText.text = "Score: 0%";
    }

    private void Update()
    {
        timer.fillAmount = timerSystem.fillAmount;
        if (timerSystem.loadNextQuestion)
        {
            DisplayNextQuiz();
            timerSystem.loadNextQuestion = false;
        }
    }

    void DisplayQuiz()
    {
        question.text = quizzes[currentQuiz].GetQuestion().ToString();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizzes[currentQuiz].GetAnswer(i).ToString();
        }

        correctAnswer = quizzes[currentQuiz].GetCorrectAnswer();
        SetButtonSpriteState();
    }

    void DisplayNextQuiz()
    {
        if (currentQuiz >= 0 && currentQuiz <= 4)
        {
            DisplayQuiz();
            canAnswered = true;
            SetButtonState(canAnswered);
            currentQuiz++;
            sliderNumberQuiz.value = currentQuiz;
        }
        else
        {
            completeQuiz = true;
        }

    }

    public void AnswerUserClick(int index)
    {
        if (canAnswered)
        {
            if (index == correctAnswer)
            {
                buttons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                question.text = "Correct";
                scoreSystem.Bonus();
                scoreText.text = "Score: " + scoreSystem.CurrentScore.ToString() + "%";
            }
            else
            {
                buttons[correctAnswer].GetComponent<Image>().sprite = correctAnswerSprite;
                question.text = quizzes[currentQuiz - 1].GetAnswer(correctAnswer).ToString();
            }
            canAnswered = false;
            SetButtonState(canAnswered);
        }
    }

    public void SetButtonSpriteState()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    public void SetButtonState(bool state)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = state;
        }
    }

}
