using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private float completeAnswerTime;

    private float runTime;
    public float fillAmount;
    public bool loadNextQuestion = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        runTime -= Time.deltaTime;

        if (runTime > 0)
        {
            fillAmount = runTime / completeAnswerTime;
        }
        else
        {
            runTime = completeAnswerTime;
            loadNextQuestion = true;

        }
    }
}
