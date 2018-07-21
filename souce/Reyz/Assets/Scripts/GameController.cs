using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.IO;

public class GameController : MonoBehaviour
{
    public bool DontDestroy;

    public static int CurrentLevel;

    public static Camera MapCamera;

    public static GameObject Player;

    public static bool DebugMap = false;

    public static bool RenderMap = false;

    public static bool FirstLevelComplete;

    //Level Completion Times
    public static float FirstLevelTime;
    public static float Level1Time;
    public static float Level2Time;

    void Awake()
    {
        if (DontDestroy == true)
            DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
            Player = GameObject.FindGameObjectWithTag("Player");

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

            if (CurrentLevel >= 3)
            {

                if (Input.GetKey(KeyCode.M))
                    {
                        DebugMap = true;
                    }
                else
                    {
                        DebugMap = false;
                    }


            if (DebugMap == true)
                RenderMap = true;

            if (DebugMap == false)
                RenderMap = false;

            if (RenderMap == true)
            {
                GameObject.FindGameObjectWithTag("MapCamera").GetComponent<Camera>().enabled = true;

                //Disable player control
                if (Player != null)
                {
                    Player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                    Player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                    Player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;
                    Player.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                    Player.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                }
            }

            if (RenderMap == false)
            {
                GameObject.FindGameObjectWithTag("MapCamera").GetComponent<Camera>().enabled = false;

                //Enable player control
                if (Player != null)
                {
                    Player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                    Player.GetComponent<FirstPersonController>().m_RunSpeed = 10;
                    Player.GetComponent<FirstPersonController>().m_JumpSpeed = 10;
                    Player.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                    Player.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                }
            }
        }
    }

    public static void UnlockGame()
    {
        File.Create(Application.dataPath + "/load.dat");
        DevConsole.Console.Log("Game unlocked! Reload the game!", Color.green);
    }

    public static void LockGame()
    {
        if(File.Exists(Application.dataPath + "/load.dat"))
        {
            File.Delete(Application.dataPath + "/load.dat");
            DevConsole.Console.Log("Game Locked! Reload!", Color.red);
        }
    }
}