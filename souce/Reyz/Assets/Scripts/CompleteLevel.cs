using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public bool FirstLevel;
    public GameObject TimerObject;

    //public GameObject Player;

    public Text CompletionTimeText = null;

    public static string minutes = string.Empty;
    public static string seconds = string.Empty;
    public GameObject UIPanel = null;

    public GameObject DefaultEndMenu;
    public GameObject SecondaryEndMenu;
    public GameObject SaveConfirmation;

    public GameObject LevelCompleteText;

    public bool Pause = false;

    //---------------------------------

    void OnTriggerEnter(Collider Col)
    {
        if(Col.CompareTag("Player") == true)
        {
            minutes = Timer.Minutes;
            seconds = Timer.Seconds;

            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;

            if (FirstLevel == true)
                GameController.FirstLevelComplete = true;

            Destroy(TimerObject);

            if (CompletionTimeText != null)
            {
                if (UIPanel != null)
                {
                    UIPanel.SetActive(true);
                    LevelCompleteText.SetActive(true);
                    CompletionTimeText.text = minutes + " minutes\nand " + seconds + " seconds!\n" + "\n" + minutes + ':' + seconds;
                    DefaultEndMenu.SetActive(true);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pause == false)
            {
                UIPanel.SetActive(true);
                CompletionTimeText.text = "Paused";
                LevelCompleteText.SetActive(false);
                DefaultEndMenu.SetActive(true);

                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
                Time.timeScale = 0;
                Pause = true;
            }

            else if(Pause == true)
            {
                UIPanel.SetActive(false);
                DefaultEndMenu.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
                Time.timeScale = 1;
                Pause = false;
            }
        }
    }

    //-------------------------------
    // UI controls

    public void Retry()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        GameController.Player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
        LoadingScreenManager.LoadScene(GameController.CurrentLevel);
    }

    public void Save()
    {
        SaveLoad.Save();
        DevConsole.Console.Log("Game saved.", Color.green);
        SaveConfirmation.SetActive(true);
        Invoke("DisableSaveConf", 2f);
    }

    public void ReturnMenu()
    {
        DefaultEndMenu.SetActive(false);
        SecondaryEndMenu.SetActive(true);
    }

    public void NextLevel()
    {
        DevConsole.Console.Log("Error: NextLevel() null function", Color.red);
    }

    public void RejectSave()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        LoadingScreenManager.LoadScene(1);
    }

    public void DenyReturn()
    {
        SecondaryEndMenu.SetActive(false);
        DefaultEndMenu.SetActive(true);
    }

    public void DisableSaveConf()
    {
        SaveConfirmation.SetActive(false);
    }

    public void ConfirmSave()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        Save();
        SecondaryEndMenu.SetActive(false);
        DefaultEndMenu.SetActive(true);
        Invoke("RejectSave", 2);
    }
}
