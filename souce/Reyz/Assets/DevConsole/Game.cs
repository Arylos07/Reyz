using UnityEngine;
using DevConsole;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    [Command]
    static void TimeScale(float value)
    {
        Time.timeScale = value;
        Console.Log("Time scale set to " + value, Color.green);
    }

    [Command]
    static void ShowTime()
    {
        Console.Log(Time.time.ToString() + " seconds of play.");
    }

    [Command]
    static void LoadLevel(int value)
    {
        SceneManager.LoadScene(value);
    }

    [Command]
    static void FirstLevel(bool value)
    {
        GameController.FirstLevelComplete = value;
        Console.Log("FirstLevelComplete set to " + value, Color.green);
    }

    [Command]
    static void qqq()
    {
        Application.Quit();
    }

    [Command]
    static void Save()
    {
        SaveLoad.Save();
        Console.Log("Game saved.", Color.green);
    }

    [Command]
    static void Delete()
    {
        SaveLoad.Delete();
        Console.Log("Save information deleted!", Color.red);
    }

    [Command]
    static void SetTimer(int value)
    {
        if (Timer.TimeRecord <= value)
        {
            Timer.TimeRecord = value;
            Console.Log(value + " Added to timer!", Color.green);
        }

        else
        {
            Timer.TimeRecord = value;
            Console.Log(value + " Removed from Timer!", Color.red);
        }
        
    }

    [Command]
    static void Unlock(string value)
    {
        if (value == "Ux395248")
        {
            GameController.UnlockGame();
        }
        else
        {
            Console.LogError("Error, cannot unlock game!");
        }
    }

    [Command]
    static void Lock(string value)
    {
        if (value == "Ux395248")
        {
            GameController.LockGame();
        }
        else
        {
            Console.LogError("Error, cannot lock game!");
        }
    }
}