using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class player : MonoBehaviour
{
    // public GameObject detector;
    public Transform movePoint;
    public float speedRate = 5f;
    public LayerMask wallMask;
    public LayerMask objectiveMask;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    private void playerMovement(){
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speedRate * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f){
            if(Math.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, wallMask)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }else{
                    Debug.Log("hit");
                }
                
            }else if(Math.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, wallMask)){
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                
                }else{
                    Debug.Log("hit");
                }
            }
        }
        

    }

    private void collectObjective(){
        if(Physics2D.OverlapCircle(movePoint.position, 0.2f, objectiveMask)){
            Destroy(Physics2D.OverlapCircle(movePoint.position, 0.2f, objectiveMask).gameObject);
            Debug.Log("collected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
}
