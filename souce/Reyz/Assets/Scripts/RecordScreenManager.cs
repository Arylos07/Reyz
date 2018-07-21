using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScreenManager : MonoBehaviour
{
    public Text TutorialLevelText = null;
    public string TutorialLevelPrefix = string.Empty;

    public Text Level1Text = null;
    public string Level1Prefix = string.Empty;

    public Text Level2Text = null;
    public string Level2Prefix = string.Empty;

    //------------------------------
    // minutes and seconds variables.
    public static string Minutes1 = string.Empty;
    public static string Seconds1 = string.Empty;

    public static string Minutes2 = string.Empty;
    public static string Seconds2 = string.Empty;

    public static string Minutes3 = string.Empty;
    public static string Seconds3 = string.Empty;

    void Awake()
    {
        if (GameController.FirstLevelComplete != false)
        {
            Minutes1 = Mathf.Floor(GameController.FirstLevelTime / 60).ToString("00");
            Seconds1 = Mathf.Floor(GameController.FirstLevelTime % 60).ToString("00");
            TutorialLevelText.text = TutorialLevelPrefix + Minutes1 + ':' + Seconds1;
        }
        else
            TutorialLevelText.text = TutorialLevelPrefix + "Not Completed!";

        if (GameController.Level1Time != 0)
        {
            Minutes2 = Mathf.Floor(GameController.Level1Time / 60).ToString("00");
            Seconds2 = Mathf.Floor(GameController.Level1Time % 60).ToString("00");
            Level1Text.text = Level1Prefix + Minutes2 + ':' + Seconds2;
        }
        else
            Level1Text.text = Level1Prefix + "Not Completed!";

        if (GameController.Level2Time != 0)
        {
            Minutes3 = Mathf.Floor(GameController.Level2Time / 60).ToString("00");
            Seconds3 = Mathf.Floor(GameController.Level2Time % 60).ToString("00");
            Level2Text.text = Level2Prefix + Minutes3 + ':' + Seconds3;
        }
        else
            Level2Text.text = Level2Prefix + "Not Completed!";
    }
}
