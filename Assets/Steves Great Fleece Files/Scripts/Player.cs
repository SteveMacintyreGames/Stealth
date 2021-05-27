using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent _playerAgent;
    Animator _animator;
    Vector3 _destination;

    private Vector3 _target;

    void Start()
    {
       _playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
       _animator = transform.GetChild(0).GetComponent<Animator>();
       //_animator.GetComponentInChildren<Animator>() also works.
       
     
    }
    void Update()
    {
        PointAndClick();
        ReachDestinationCheck();
    }

    //if left click
    //cast a ray from mouse position
    //debug floor position hit
    //create object at floor position.

    void PointAndClick()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin,out hitInfo))
            {                
                //Debug.Log(hitInfo.point);
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hitInfo.point;
                _target = hitInfo.point;
                _playerAgent.SetDestination(_target);
                _animator.SetBool("isWalking",true);
            }
        }
    }

    void ReachDestinationCheck()
    {   
        //distance = between player & destination.
        //check if the distance < 1 unit from destination. then stop animation.


        //if player object == destination
        // _anim.SetBool(false);

        float distance = Vector3.Distance(transform.position, _target);
        //Debug.Log(distance);
        if(distance <2.1f)
        {
            _animator.SetBool("isWalking", false);
        }   
  
    }

}