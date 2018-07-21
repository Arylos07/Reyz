using UnityEngine;
using System.Collections;
//------------------------------
public class ProxyDamage : MonoBehaviour
{
    //------------------------------
    public bool DealsDamage;
    //Damage per second
    public float DamageRate = 10f;
    //------------------------------
    void OnTriggerStay(Collider Col)
    {
        if (DealsDamage == true)
        {
            Health H = Col.gameObject.GetComponent<Health>();

            if (H == null) return;

            H.HealthPoints -= DamageRate * Time.deltaTime;
        }
    }
    //------------------------------
}
//------------------------------