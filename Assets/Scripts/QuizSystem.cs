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

    [Header("Question")]
    [SerializeField] private TextMeshProUGUI question;

    [Header("Button Answer")]
    [SerializeField] private List<Button> buttons = new List<Button>();
    private int correctAnswer;

    [Header("Sprite Button")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Time")]
    [SerializeField] private Image timer;
    TimerSystem timerSystem;

    // player answered or not?
    public bool isAnswered = false;

    void Awake()
    {
        timerSystem = FindObjectOfType<TimerSystem>();
    }

    // private void Start()
    // {
    //     DisplayNextQuiz();
    // }

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
        SetButtonState();
    }

    void DisplayNextQuiz()
    {
        if (currentQuiz >= 0 && currentQuiz <= 4)
        {
            DisplayQuiz();  
            currentQuiz++;
        }

    }

    public void AnswerUserClick(int index)
    {
        if (index == correctAnswer)
        {
            buttons[index].GetComponent<Image>().sprite = correctAnswerSprite;
            question.text = "Correct";
            isAnswered = true;
        }
        else
        {
            buttons[correctAnswer].GetComponent<Image>().sprite = correctAnswerSprite;
            question.text = quizzes[currentQuiz-1].GetAnswer(correctAnswer).ToString();
            isAnswered = true;
        }
    }

    public void SetButtonState()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

}
