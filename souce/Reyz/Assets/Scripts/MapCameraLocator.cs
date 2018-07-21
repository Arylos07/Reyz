using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraLocator : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {

        if (GameController.CurrentLevel == 3)
        {
            transform.position = new Vector3(54, 120, 48);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            gameObject.GetComponent<Camera>().orthographicSize = 56.12f;
        }

        if(GameController.CurrentLevel == 5)
        {
            transform.position = new Vector3(48, 444, 48);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            gameObject.GetComponent<Camera>().orthographicSize = 56.12f;
        }

        if (GameController.CurrentLevel == 6)
        {
            transform.position = new Vector3(46, 110, 47);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            gameObject.GetComponent<Camera>().orthographicSize = 56.12f;
        }
    }
}
