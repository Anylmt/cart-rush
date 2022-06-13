using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform cartTransform;
    [SerializeField] private float enemySpeed = 2f;
    Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, cartTransform.position, enemySpeed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(cartTransform);
    }
}
