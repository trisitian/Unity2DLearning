using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question; 
    [SerializeField] GameObject[] answers;
    // Start is called before the first frame update
    void Start()
    {
        questionText.text = question.GetQuestion();
        populateQuestions();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populateQuestions(){

        for(int i = 0; i < answers.Length; i++){
            TextMeshProUGUI buttonTest = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTest.text = question.getAnswer(i);
        }
    }

}
