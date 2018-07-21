using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text TutorialText = null;

    Coroutine co;

    public bool WASDUsed = false;
    public bool LShiftUsed = false;
    public bool MapUsed = false;
    public bool JumpUsed = false;
    public bool DamageReceived = false;
    public bool TutorialPass = false;

    public GameObject Player = null;

    public Animator PanelAnimator;
    public Animator UIAnimator;

    public GameObject MapText;

    public float FadeDuration = 1f;
    public float TextDelay = 1f;
    public float MapTextDelay = 3f;

    private void Start()
    {
        TutorialText.text = "Use the WASD keys to move. Use your mouse to look around.";

        if (GameObject.FindGameObjectWithTag("Player") != null)
            Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
            Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (GameController.FirstLevelComplete == true)
            Destroy(gameObject);

        if (Input.anyKeyDown)
        {
            if (WASDUsed == false)
                StartCoroutine(WASDPass());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && WASDUsed)
        {
            if (LShiftUsed == false)
                StartCoroutine(LShiftPass());
        }

        if (Input.GetKeyDown(KeyCode.M) && WASDUsed && LShiftUsed)
        {
            if (MapUsed == false)
            {
                co = StartCoroutine(MapPass());
                PanelAnimator.SetTrigger("MapOpened");
                MapText.SetActive(true);
            }
        }

        if(Input.GetKeyUp(KeyCode.M) && WASDUsed && LShiftUsed && MapUsed)
        {
            MapText.SetActive(false);
            PanelAnimator.SetTrigger("MapClosed");
            UIAnimator.SetTrigger("Hide");
            StopCoroutine(co);

            if (JumpUsed == false)
                StartCoroutine(JumpPass());
        }

        if(Player.GetComponent<Health>().HealthPoints < 100 && WASDUsed && LShiftUsed && MapUsed && JumpUsed)
        {
            if (DamageReceived == false)
                StartCoroutine(DamagePass());
        }

        if(TutorialPass == true)
        {
            StartCoroutine(TutorialComplete());
        }
    }

    IEnumerator WASDPass()
    {
        WASDUsed = true; 

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "Use Left Shift to sprint while moving.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);
    }

    IEnumerator LShiftPass()
    {
        LShiftUsed = true;

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "Open the level map by pressing and holding m.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);
    }

    IEnumerator MapPass()
    {
        MapUsed = true;

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "This map shows you the level layout. You appear as the red dot. The Daemon is not visible on this map.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "You are unable to move when the map is open. However, the Daemon cannot move as well. Take this time to plan your moves carefully.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "It is important to remember that when the map is open, nothing moves, however time still moves on so don't take too long to plan.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "The Daemon will only attack you at night, and then hide during the day. Don't waste too much time in the map.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "The dark energy shows where you started from. You must reach the white light at the end in order to complete the maze.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        UIAnimator.SetTrigger("Display");
        yield return new WaitForSeconds(2);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.
        MapText.SetActive(false);
    }

    IEnumerator JumpPass()
    {
        JumpUsed = true;

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "Walls with spikes are able to be jumped over, but not easily. Use the spacebar to jump.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);
    }

    IEnumerator DamagePass()
    {
        DamageReceived = true;

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "Jumping over walls does quite a bit of damage to you, so be mindful; if your health is reduced to 0, you lose.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "Your health is the bar and number on the bottom of the screen. Lucky for you, your health regenerates over time.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "The Daemon also damages you if you get too close to it so don't let it catch you. Also remember that the 'p' key is your friend; it will pause the game for you.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        yield return new WaitForSeconds(MapTextDelay); //Allow player to read text.

        TutorialPass = true;
    }

    IEnumerator TutorialComplete()
    {
        yield return new WaitForSeconds(TextDelay);
        TutorialText.CrossFadeAlpha(0, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);

        TutorialText.text = "You have just completed the tutorial! Complete the maze to continue.";
        TutorialText.CrossFadeAlpha(1, FadeDuration, true);
        yield return new WaitForSeconds(FadeDuration);
    }
}
