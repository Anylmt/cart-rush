using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform cartTransform;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] Rigidbody enemyRb;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            Vector3.Distance(transform.position, cartTransform.position);

            if (Vector3.Distance(transform.position, cartTransform.position) > 1.8f)
            {
                Move();
            }
            //else
            //{
            //    ReturnPosition();
            //}
        }
    }

    private void Move()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, cartTransform.position + Vector3.up, enemySpeed * Time.fixedDeltaTime);
        enemyRb.MovePosition(pos);
        transform.LookAt(cartTransform.position + Vector3.up);
    }

    //private void ReturnPosition()
    //{
    //    if (Vector3.Distance(transform.position, startPosition) > 1.8f)
    //    {
    //        transform.position = startPosition;
    //    }
    //}
}
