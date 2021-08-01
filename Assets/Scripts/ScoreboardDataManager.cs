using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Serialise data

//Purpose: Open and Save data to file
public class ScoreboardDataManager : MonoBehaviour
{
    //Collects arguments from ScoreEntry and uses them to save data to file
    public void SaveData(string playerName, string homeroomName, int playerScore, string fileName)
    {
        List<ScoreboardEntry> tempDataList;
        tempDataList = LoadData(fileName);
        tempDataList.Add(new ScoreboardEntry() { name = playerName, homeroom = homeroomName, score = playerScore });
        tempDataList = SortData(tempDataList);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        bf.Serialize(file, tempDataList);
        file.Close();
    }

    //Takes a list of objects and sort them in order by score, highest to lowest
    private List<ScoreboardEntry> SortData(List<ScoreboardEntry> dataList)
    {
        ScoreboardEntry temp;

        for (int i = 0; i < dataList.Count; i++)
        {
            for (int j = i + 1; j < dataList.Count; j++)
            {
                if (dataList[j].score > dataList[i].score)
                {
                    temp = dataList[i];
                    dataList[i] = dataList[j];
                    dataList[j] = temp;
                }
            }
        }
        return dataList;
    }

    //Load data from file based on argument file name
    public List<ScoreboardEntry> LoadData(string fileName)
    {
        List<ScoreboardEntry> tempDataList = new List<ScoreboardEntry>();

        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);

            tempDataList = (List<ScoreboardEntry>)bf.Deserialize(file);
            file.Close();
        }
        return tempDataList;
    }

    //Deletes file based on file name
    public void DeleteFile(string fileName)
    {
        string filePath = Application.persistentDataPath + fileName;

        if (File.Exists(filePath))
        {
            // print debug message file found and deleted
            File.Delete(filePath);
        }
        else
        {
            Debug.Log("Could not delete file: " + filePath);
        }
    }
}

//Object to define user scoring info
[Serializable]
public class ScoreboardEntry
{

    public string name;
    //Categorise by form room
    public string homeroom;
    public int score;

}

