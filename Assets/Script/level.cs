using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    // checkObjective() is called when an objective is collected

    public Transform player;
    public LayerMask objectiveMask;

    private int objectiveCount;

    private void Start() {

    objectiveCount = GameObject.FindGameObjectsWithTag("objectives").Length;
    Debug.Log(objectiveCount);
    }
    public void collectObjective(){
        if(Physics2D.OverlapCircle(player.position, 0.2f, objectiveMask)){
            Debug.Log("collected");
            objectiveCount--;
            Destroy(Physics2D.OverlapCircle(player.position, 0.2f, objectiveMask).gameObject);
        checkObjective();
        }
    }

    private void checkObjective(){
        // if all objectives are collected, call levelComplete() in levelLogic.cs
        if(objectiveCount == 0){
            Debug.Log("level complete");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
    collectObjective();
    }
}
