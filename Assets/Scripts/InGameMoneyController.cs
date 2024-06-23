using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameMoneyController : MonoBehaviour
{
    [SerializeField] int moneyToAdd;
    [SerializeField] int playerId;

    public void AddMoney()
    {
        DataAdapter.AddMoney(playerId, moneyToAdd);
    }

    public int GetMoney()
    {
        var money = DataAdapter.GetPlayerMoney(playerId);
        return money.money;
    }
}
