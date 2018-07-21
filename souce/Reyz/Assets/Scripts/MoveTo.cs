// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class MoveTo : MonoBehaviour
{
    public GameObject Player;
    public Transform goal = null;
    public GameObject HideAt;

    public static float CurrentTime;

    public float StartSearchTime;
    public float StartSearchTime2;
    public float EndSearchTime;
    public float EndSearchTime2;

    public Animator anim;

    void FixedUpdate()
    {
        if (CurrentTime > StartSearchTime || CurrentTime < StartSearchTime2)
            goal = Player.transform;
        else
            goal = HideAt.transform;

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        if (FirstPersonController.m_IsWalking == false)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 8;
            anim.SetTrigger("Running");
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 5;
            anim.SetTrigger("Running");
        }

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled == false)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
            anim.SetTrigger("Idle");
        }

        if (GameController.RenderMap == true)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
            anim.SetTrigger("Idle");
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 5;
            anim.SetTrigger("Running");
        }
    }
}