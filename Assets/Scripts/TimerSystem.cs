using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private float completeAnswerTime = 3f;

    private float runTime;
    public float fillAmount;
    public bool loadNextQuestion = false;


    // Start is called before the first frame update
    void Start()
    {
        runTime = completeAnswerTime;
        fillAmount = runTime / completeAnswerTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        runTime -= Time.deltaTime;
        if (fillAmount > 0)
        {
            fillAmount = runTime / completeAnswerTime;
        }
        else
        {
            runTime = completeAnswerTime;
            fillAmount = runTime / completeAnswerTime;
            loadNextQuestion = true;
        }
    }
}
