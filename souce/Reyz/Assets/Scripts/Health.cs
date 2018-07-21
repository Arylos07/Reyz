using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
//------------------------------
public class Health : MonoBehaviour
{
    public bool ShouldDestroyOnDeath = true;
    public bool Suicide;

    public GameObject DeathPanel;
    public GameObject Menu;

    public GameObject TimerObject;

    public Image Fade;

    public Image HealthBar;
    public Text HealthText;

    public float FadeDuration;

    public float HealthRegenRate;

    public void Awake()
    {
        Fade.CrossFadeAlpha(0, FadeDuration, true);
    }
    //------------------------------
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;

            if (_HealthPoints <= 0)
            {
                gameObject.GetComponent<FirstPersonController>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                DeathPanel.SetActive(true);
                Menu.SetActive(true);

                Destroy(TimerObject);
                Fade.CrossFadeAlpha(1, FadeDuration, true);
            }
        }
    }

    private void Update()
    {
        HealthBar.fillAmount = _HealthPoints / 100;

        if (_HealthPoints >= 100)
            HealthText.text = "100%";

        else if (_HealthPoints <= 100 && _HealthPoints >= 0)
            HealthText.text = _HealthPoints.ToString("F2") + "%";

        else if (_HealthPoints <= 0)
            HealthText.text = "0.00%";

        if (_HealthPoints <= 100 && _HealthPoints >= 0)
        {
            _HealthPoints += HealthRegenRate * Time.deltaTime;
        }
    }
    //------------------------------
    [SerializeField]
    private float _HealthPoints = 100f;
}
//------------------------------