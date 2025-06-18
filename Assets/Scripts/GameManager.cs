using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    QuizSystem quizSystem;
    EndGameSystem endGameSystem;

    private void Awake()
    {
        quizSystem = FindObjectOfType<QuizSystem>();
        endGameSystem = FindObjectOfType<EndGameSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        quizSystem.gameObject.SetActive(true);
        endGameSystem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quizSystem.completeQuiz)
        {
            quizSystem.gameObject.SetActive(false);
            endGameSystem.gameObject.SetActive(true);
        }
    }
}
