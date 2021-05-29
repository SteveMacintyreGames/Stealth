using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{ 
    public List<Transform> wayPoints; 
    private NavMeshAgent _guardAgent;
    private Animator _anim;

    [SerializeField] private int _currentTarget;
    private bool _targetReached;

    private bool _reverse;
    private bool _walking;

    float distance;
   
    void Start()
    {   
        _guardAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _walking = false;
         
    }
        

    // Update is called once per frame
    void Update()
    {
        AnimateWalk();
        if (wayPoints.Count <2)
        {
            return;
        }
       if (wayPoints.Count >0 && wayPoints[_currentTarget] != null)
       {
           _guardAgent.SetDestination(wayPoints[_currentTarget].position);
           
           
            //check distance between guard and destination
            //if distance is less than 1 unit
            // increment current target.

            distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance >1f)
            {
                _walking = true;
            }

            if(distance < 1f && _targetReached == false)
            {             
                _targetReached = true;

                StartCoroutine(WaitBeforeMoving());               
            }
       }
       
    }
    void AnimateWalk()
    {
        if (_anim != null)
        {
            if (_walking)
            {
                _anim.SetBool("isWalking",true);
            }
            else
            {
                _anim.SetBool("isWalking",false);
            }
        }
  
    }

    IEnumerator WaitBeforeMoving()
    {
        var timeToWait = Random.Range(2f,5f);
        if(_currentTarget == wayPoints.Count-1)
        {
           _walking = false;
            yield return new WaitForSeconds(timeToWait);
            _walking = true;
        }
        else if (_currentTarget == 0)
        {
            _walking = false;
            yield return new WaitForSeconds(timeToWait);
            _walking = true;
        }
       
        
        _targetReached = false;
        if (!_reverse)
                {                       
                        if (_currentTarget == wayPoints.Count-1)
                        {
                            _reverse = true;
                        }
                        else
                        {
                            _currentTarget ++;
                        }   
 
                }else
                {   
                        if (_currentTarget == 0)
                        {
                            _reverse = false;
                        }
                        else
                        {
                            _currentTarget --;
                        }                
                }
                yield return 0;
    }
}
