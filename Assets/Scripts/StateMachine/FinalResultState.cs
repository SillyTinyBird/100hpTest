using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalResultState : StateBase
{
    [SerializeField] ScoreManager yourScoreManager;
    [SerializeField] ScoreManager enemyScoreManager;

    [SerializeField] TextMeshProUGUI sumYour;
    [SerializeField] TextMeshProUGUI sumEnemy;

    [SerializeField] TextMeshProUGUI money;

    [SerializeField] InGameMoneyController inGameMoneyController;

    public override void TickState(StateController context)
    {
        this.UpdateState(context);
    }
    public override void UpdateState(StateController context)
    {
        //end of the road
    }
    public override void InitState(StateController context)
    { 
        sumYour.text = sumYour.text.Replace("{score}", yourScoreManager.Score.ToString()).Replace("{right}", yourScoreManager.Rights.ToString());
        sumEnemy.text = sumEnemy.text.Replace("{score}", enemyScoreManager.Score.ToString()).Replace("{right}", enemyScoreManager.Rights.ToString());

        money.text = money.text.Replace("{money}", inGameMoneyController.GetMoney().ToString());

        if (yourScoreManager.Score > enemyScoreManager.Score)
        {
            inGameMoneyController.AddMoney();
            money.text += " + 10 \n Награда за победу";
        }

        base.UpdateGameObjects(this.gameObjectsToDisable, this.gameObjectsToEnable);
    }
}
