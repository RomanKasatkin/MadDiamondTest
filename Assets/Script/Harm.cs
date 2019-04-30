using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harm : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag=="Victim")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
