using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionLoader : MonoBehaviour 
{
    [SerializeField] private List<ButtonController> buttonList;
    [SerializeField] private List<EnemyPlateController> enemyPanels;
    [SerializeField] private TextMeshProUGUI question;

    private int[] shuffleIds = { 0, 1, 2, 3 };

    public bool LoadQuestions()
    {
        var result = true;
        QuestionModel question = null;
        var questionsStillLeft = QuestionManager.Instance.TryGetNextQuestion(out question);

        if (!questionsStillLeft || question is null)
            result = false;

        this.question.text = question.question;

        var rng = new System.Random();
        rng.Shuffle(shuffleIds);

        buttonList[shuffleIds[0]].SetButton(question.correctAnswer, true);
        buttonList[shuffleIds[1]].SetButton(question.wrongAnswer1, false);
        buttonList[shuffleIds[2]].SetButton(question.wrongAnswer2, false);
        buttonList[shuffleIds[3]].SetButton(question.wrongAnswer3, false);

        enemyPanels[shuffleIds[0]].SetEnemyAnswer(true);
        enemyPanels[shuffleIds[1]].SetEnemyAnswer(false);
        enemyPanels[shuffleIds[2]].SetEnemyAnswer(false);
        enemyPanels[shuffleIds[3]].SetEnemyAnswer(false);

        return result;
    }
}
