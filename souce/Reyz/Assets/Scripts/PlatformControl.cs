using UnityEngine;
using System.Collections;

public class PlatformControl : MonoBehaviour
{
    public float platformMovementRange = 100;
    public float platformSpeed = 10;

    private Vector3 initialPosition;

    public enum Direction
    {
        Horizontal,
        Vertical
    }

    public Direction platformType;
    
	// Use this for initialization
	void Start ()
    {
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(platformType == Direction.Horizontal )
        {

            //transform.Translate(Vector3.forward * Mathf.Sin(Time.time % (2 * Mathf.PI)));
            //transform.Translate(Vector3.forward * Mathf.Sin((Time.time) % (2 * Mathf.PI)));
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z +  2*Mathf.Sin((Time.time % (2 * Mathf.PI))));
            //transform.Translate(Vector3.forward * (Mathf.Sin((Time.time % (2 * Mathf.PI))) - (transform.position.z - initialPosition.z)));
        }

        //Debug.Log(Mathf.Sin(2 * (Time.time % (2 * Mathf.PI))) - (transform.position.z - initialPosition.z));
            
	}
}
