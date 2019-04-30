using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if(HP<1)
        {
            Destroy(gameObject);
        }
        else
        {
            HP--;
        }
    }
}
