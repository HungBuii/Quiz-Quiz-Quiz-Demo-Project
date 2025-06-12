using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question")]
public class QuizSO : ScriptableObject
{
    [TextArea(1, 6)]
    [SerializeField] private string question;
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswer;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }

}
