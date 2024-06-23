using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<EnemyPlateController> enemyPlateControllers;
    [SerializeField] protected ScoreManager scoreManager;

    public void RandomAnswer()
    {
        var shuffledPlates = enemyPlateControllers.ToArray();
        var rng = new System.Random();
        rng.Shuffle(shuffledPlates);
        var result = shuffledPlates.First().ShowEnemyResult();

        scoreManager.UpdateScore(Random.value, result);
    }

}
