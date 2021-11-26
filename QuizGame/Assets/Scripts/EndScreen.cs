using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    ScoreKeeper s;
    // Start is called before the first frame update
    void Awake()
    {
        s = FindObjectOfType<ScoreKeeper>();
    }


    public void ShowScore(){
        finalScore.text = "Congragulations!\n You got a score of " + s.CalculateCorrectAnswers() + "%";
    }
}
