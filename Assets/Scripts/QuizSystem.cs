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
    private int currentQuiz;

    [Header("Question")]
    [SerializeField] private TextMeshProUGUI question;

    [Header("Button Answer")]
    [SerializeField] private List<Button> buttons = new List<Button>();
    private int correctAnswer;

    [Header("Sprite Button")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    private float time;


    void Awake()
    {

    }

    private void Start()
    {
        DisplayNextQuiz();
    }

    private void Update()
    {
        
    }

    void DisplayQuiz()
    {
        question.text = quizzes[currentQuiz].GetQuestion().ToString();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizzes[currentQuiz].GetAnswer(i).ToString();
        }
        
        correctAnswer = quizzes[currentQuiz].GetCorrectAnswer();
    }

    void DisplayNextQuiz()
    {
        if (currentQuiz >= 0 && currentQuiz <= 4)
        {
            DisplayQuiz();
        }

    }

    public void AnswerUserClick(int index)
    {
        if (index == correctAnswer)
        {
            buttons[index].GetComponent<Image>().sprite = correctAnswerSprite;
            question.text = "Correct";
        }
        else
        {
            buttons[correctAnswer].GetComponent<Image>().sprite = correctAnswerSprite;
            question.text = quizzes[currentQuiz].GetAnswer(correctAnswer).ToString();
        }
    }

}
