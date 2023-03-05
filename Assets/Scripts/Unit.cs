using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    static string isWalking = "IsWalking";
    [SerializeField] private Animator unitAnimator;
    [SerializeField] float stoppingDistance = .1f;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rotateSpeed = 10f;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveSpeed * moveDirection * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            unitAnimator.SetBool(isWalking, true);
        }
        else
        {
            unitAnimator.SetBool(isWalking, false);
        }


    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;

    }

}
