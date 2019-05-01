using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoodController : MonoBehaviour
{
    public bool agressiveFlag;

    public RandomMoovement randomMoovement;
    public AtackMod atackMod;
    public NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        randomMoovement = GetComponent<RandomMoovement>();
        atackMod = GetComponent<AtackMod>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void MoodToggle()
    {
        agressiveFlag = !agressiveFlag;
    }

    public void SetIdle()
    {
        agressiveFlag = false;
        atackMod.isActive = false;
        GameObject.Find("AgressionToggle").GetComponent<Toggle>().isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(agressiveFlag)
        {
            randomMoovement.enabled = false;
            navAgent.enabled = false;
            atackMod.enabled = true;
            atackMod.isActive = true;
            
            Renderer rend = GetComponent<Renderer>();            
            rend.material.SetColor("_Color", Color.red);
        }
        else
        {
            randomMoovement.enabled = true;
            navAgent.enabled = true;
            atackMod.enabled = false;
            atackMod.isActive = false;
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.green);
        }
    }
}
