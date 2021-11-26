using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject {

    [TextArea(2,6)]
    [SerializeField] string question = "Enter new Question text";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int answerValue;



    public string GetQuestion(){
        return question;
    }
    
    public int getAnswerIndex(){
        return answerValue;
    }

    public string getAnswer(){
        return answers[getAnswerIndex()];
    }
    public string getAnswer(int index){
        return answers[index];
    }
}
