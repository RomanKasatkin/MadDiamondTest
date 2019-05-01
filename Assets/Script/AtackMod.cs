using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMod : MonoBehaviour
{
    public bool isActive;

    public float speed;
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;
    public GameObject gunPosition;
    

    public GameObject target;
    private float fireTimer;

    public bool targetLocked;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Victim");
        fireTimer = 0;
        
    }

    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Victim");
        fireTimer = 0;
    }

    void Update()
    {
        if (target != null)
        {
            gameObject.transform.LookAt(new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z));
            if (!targetLocked)
            {                              
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (Vector3.Distance(gameObject.transform.position, target.transform.position) >= 4)
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
                else
                    gameObject.transform.Translate(Vector3.zero);
                
                fireTimer -= Time.deltaTime;
                if (fireTimer <= 0)
                {
                    Shoot();
                    fireTimer = fireRate;
                }
            }
        }
        else
        {
            gameObject.GetComponent<MoodController>().SetIdle();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.name == "Victim")
            {
                targetLocked = true;                
            }
        }
    }    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Victim")
        {
            targetLocked = false;
        }
    }


    void Shoot()
    {
        GameObject shootBullet = Instantiate(bullet,gunPosition.transform.position, gunPosition.transform.rotation) as GameObject;        
        shootBullet.GetComponent<Rigidbody>().velocity = shootBullet.transform.forward*bulletSpeed;
    }
}
