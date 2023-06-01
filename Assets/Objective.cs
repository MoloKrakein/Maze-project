using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool collected = false;
    public GameObject player;
    public GameObject levelLogic;

    void Start()
    {
        player = GameObject.Find("player");    
        levelLogic = GameObject.Find("levelLogic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
