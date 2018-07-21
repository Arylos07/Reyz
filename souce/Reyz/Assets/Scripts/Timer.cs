using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string TimerPrefix = string.Empty;
    public Text TimerText = null;

    public static string Minutes = string.Empty;
    public static string Seconds = string.Empty;

    // ----------------------------
    // Maximum time to complete level (in seconds)
    public float MaxTime = 60f;
    // Determine if the Timer should be stopped or not.
    public static bool TimerStop;
    //-----------------------------
    // Countdown
    public static float TimeRecord = 0;
    //-----------------------------

    // Update is called once per frame

    void Awake()
    {
        TimeRecord = 0;
    }

    void Update()
    {
        TimeRecord += Time.deltaTime;

        Minutes = Mathf.Floor(TimeRecord / 60).ToString("00");
        Seconds = Mathf.Floor(TimeRecord % 60).ToString("00");

        if (TimerText != null)
            TimerText.text = TimerPrefix + Minutes + ':' + Seconds;
    }

    void OnDestroy()
    {
        if (GameController.CurrentLevel == 3)
            GameController.FirstLevelTime = TimeRecord;

        if (GameController.CurrentLevel == 5)
            GameController.Level1Time = TimeRecord;

        if (GameController.CurrentLevel == 6)
            GameController.Level2Time = TimeRecord;
    }
}


