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
    [SerializeField] private GameObject _coin;
    [SerializeField] private AudioClip _coinSound;
    private bool _hasThrownCoin;

    public GameObject[] guards;

    void Start()
    {
       _playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
       _animator = transform.GetChild(0).GetComponent<Animator>(); 
    }

    void Update()
    {
        PointAndClick();
        ReachDestinationCheck();
    }

    void PointAndClick()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin,out hitInfo))
            {                
                _target = hitInfo.point;
                _playerAgent.SetDestination(_target);
                _animator.SetBool("isWalking",true);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {            
            if (!_hasThrownCoin)
            {          
                _animator.SetTrigger("Throw");

                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if(Physics.Raycast(rayOrigin, out hitInfo))
                {
                    _target = hitInfo.point;
                    Instantiate(_coin, _target, Quaternion.identity);
                    SendAIToDestination(hitInfo.point);
                }
                _hasThrownCoin = true;
            }

        }
    }

    void SendAIToDestination(Vector3 coinPos)
    {
        guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            //Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
            currentGuard.walking = true;
            currentGuard.coinPos = coinPos;      

        }
    }

    void ReachDestinationCheck()
    {   
        float distance = Vector3.Distance(transform.position, _target);

        if(distance <2.1f)
        {
            _animator.SetBool("isWalking", false);
        }   
  
    }

}