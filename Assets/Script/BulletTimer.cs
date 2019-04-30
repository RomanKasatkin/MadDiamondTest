using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    public float timeLeft;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<=0)
        {
            Destroy(gameObject);
        }
    }
}
