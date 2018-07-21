using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DevConsole;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    void Start()
    {
        //Stream the manager so it can be called at any point in the game to save any variables.
        DontDestroyOnLoad(gameObject);
    }

    //On method call SaveLoad.Save()
    public static void Save()
    {
        //Load binary coding and create a file to write to.
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/saveFile.sav");

        //Create a copy of the SaveManager to get variables to save.
        SaveManager saver = new SaveManager();
        saver.CompletedFirstLevel = GameController.FirstLevelComplete;
        saver.FirstLevelTime = GameController.FirstLevelTime;
        saver.Level1Time = GameController.Level1Time;
        saver.Level2Time = GameController.Level2Time;
        //Add other variables if needed...

        //Encrypt information
        binary.Serialize(fStream, saver);
        //Close file.
        fStream.Close();
    }

    //On method call SaveLoad.Load()
    public static void Load()
    {
        //Only load if there is an existing file.
        if (File.Exists(Application.persistentDataPath + "/saveFile.sav"))
        {
            //Load binary formatter and open the file. Decrypt the file and close it.
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/saveFile.sav", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            //Take decrypted variables and add them to the GameController so rules can be adjusted accordingly.
            GameController.FirstLevelComplete = saver.CompletedFirstLevel;
            GameController.FirstLevelTime = saver.FirstLevelTime;
            GameController.Level1Time = saver.Level1Time;
            GameController.Level2Time = saver.Level2Time;
            //Add other variables if needed...

            DevConsole.Console.Log("Load Successful!", Color.green);
        }
    }

    public static void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.sav"))
        {
            File.Delete(Application.persistentDataPath + "/saveFile.sav");
            Destroy(GameObject.FindGameObjectWithTag("GameController"));

            GameController.FirstLevelComplete = false;
            GameController.FirstLevelTime = 0;
            GameController.Level1Time = 0;
            GameController.Level2Time = 0;

            LoadingScreenManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            DevConsole.Console.Log("Delete Successful!", Color.red);
        }
    }
}

//Can be serialized
[Serializable]

//Object that records all information to be saved.
class SaveManager
{
    public bool CompletedFirstLevel;
    public float FirstLevelTime;
    public float Level1Time;
    public float Level2Time;
    //Add other variaables if needed...
}