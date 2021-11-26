using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question; 
    [SerializeField] GameObject[] answers;
    [SerializeField] Sprite defaulAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;





    // Start is called before the first frame update
    void Start()
    {
        PopulateQuestions();
    }

    void SetButtonState(bool state){
        for(int i = 0; i <answers.Length; i++){
            Button b = answers[i].GetComponent<Button>();
            b.interactable = state;
        }
    }

    void GetNextQuestion(){
        SetButtonState(true);
        PopulateQuestions();
    }

    public void OnAnswerSelect(int index){
        if(index == question.getAnswerIndex()){
            questionText.text = "Correct!";
        }else{
            questionText.text = "That's unfortunately the incorrect answer, the correct answer is \n" + question.getAnswer();
        }
        Image buttonImage = answers[question.getAnswerIndex()].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
        SetButtonState(false);
    }

    void PopulateQuestions(){

        for(int i = 0; i < answers.Length; i++){
            questionText.text = question.GetQuestion();
            TextMeshProUGUI buttonTest = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTest.text = question.getAnswer(i);
        }
    }

}
