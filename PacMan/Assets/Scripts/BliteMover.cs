using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliteMover : MonoBehaviour
{
    

    [SerializeField]
    public Transform[] wayPoints;

    [SerializeField]
    public float moveSpeed = 2f;

    int waypointIndex = 0;

    void Start(){
        transform.position = wayPoints[waypointIndex].transform.position;
        //Debug.Log("Start");
    }

    void Update(){
        Move();
        //Debug.Log("Move");
    }

    void Move(){
        transform.position = Vector3.MoveTowards(transform.position,
                                                wayPoints[waypointIndex].transform.position,
                                                moveSpeed * Time.deltaTime);
        //Debug.Log("transform");

        if (transform.position == wayPoints[waypointIndex].transform.position){
            waypointIndex += 1;
            //Debug.Log("plus 1");
        }

        if (waypointIndex == wayPoints.Length)
            waypointIndex = 0;
        //Debug.Log("index 0");
    }
    



}
