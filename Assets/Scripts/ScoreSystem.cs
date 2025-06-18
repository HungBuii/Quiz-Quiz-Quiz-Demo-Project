using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int CurrentScore { get; set; }

    public void Bonus()
    {
        CurrentScore += 20;
    }
}
