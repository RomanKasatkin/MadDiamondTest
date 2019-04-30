using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMoovement : MonoBehaviour {

    public float speed;
    public float timer;
    public int newtarget;
    public NavMeshAgent nav;
    public Vector3 pos;
    public Vector3 target;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>=newtarget)
        {
            Newtarget();
            timer = 0;
        }
	}

    void Newtarget()
    {
        Vector3 pos = gameObject.transform.position;

        target = new Vector3(pos.x + Random.Range(-speed, speed), pos.y , pos.z + Random.Range( -speed, speed));

        nav.SetDestination(target);
        newtarget = Random.Range(1, 5);
    }
}
