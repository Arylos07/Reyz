using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ResetMouseLock : MonoBehaviour
{
    public bool LockMouse;

	// Use this for initialization
	void Start ()
    {
        if (LockMouse == true)
            gameObject.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
    }
}
