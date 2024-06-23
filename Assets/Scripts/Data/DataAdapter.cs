using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
public class DataAdapter
{
    /* Обращаю внимание что адаптер подразумевает получение данных из любых источников
     * конкретно здесь реализовано хранение данных в json файлах
     * изначально я планировал хранение в базе данных но я посчитал что это слишком жирно для демонстрационных целей
     */

    private static readonly string filePathQuestions = $"Data/questions.json";
    private static readonly string filePathMoney = $"Data/money.json";

    public static QuestionListWrapper GetAllQuestions()
    {
        var json = LoadResourceTextFile(filePathQuestions);
        json = "{\"questions\":" + json + "}";//bruh
        return JsonUtility.FromJson<QuestionListWrapper>(json);
    }

    public static void AddMoney(int playerId, int moneyToAdd)
    {
        var money = GetPlayerMoney(playerId);
        /*var json = System.IO.File.ReadAllText("Assets/Resources/" + filePathMoney);
        var money = JsonUtility.FromJson<MoneyModel>(json);*/


        if (money == null || money.playerId == playerId)
            money.money += moneyToAdd;

        WriteDataToJson(money);

        //System.IO.File.WriteAllText("Assets/Resources/" + filePathMoney, JsonUtility.ToJson(money));
    }


    private static string LoadResourceTextFile(string path)
    {

        string filePath = path.Replace(".json", "");

        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

        return targetFile.text;
    }

    static string DataPath()
    {
        if (System.IO.Directory.Exists(Application.persistentDataPath))
        {
            return Path.Combine(Application.persistentDataPath, filePathMoney);
        }
        return Path.Combine(Application.streamingAssetsPath, filePathMoney);
    }

    public static MoneyModel GetPlayerMoney(int playerId)
    {
        string dataString;
        string jsonFilePath = DataPath();
        CheckFileExistence(jsonFilePath, true);

        dataString = System.IO.File.ReadAllText(jsonFilePath);
        var money = JsonUtility.FromJson<MoneyModel>(dataString);

        if (money == null || money.playerId == playerId)
            return money;

        return null;
    }


    public static void WriteDataToJson(MoneyModel money)
    {
        string jsonFilePath = DataPath();
        CheckFileExistence(jsonFilePath);

        var dataString = JsonUtility.ToJson(money);
        System.IO.File.WriteAllText(jsonFilePath, dataString);
    }

    static void CheckFileExistence(string filePath, bool isReading = false)
    {
        if (!System.IO.File.Exists(filePath))
        {
            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            System.IO.File.Create(filePath).Close();
            if (isReading)
            {
                var money = new MoneyModel();
                money.playerId = 1;
                money.money = 0;
                string dataString = JsonUtility.ToJson(money);
                System.IO.File.WriteAllText(filePath, dataString);
            }
        }
    }


}
