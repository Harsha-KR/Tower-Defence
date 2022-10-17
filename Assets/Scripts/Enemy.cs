using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;

    private int wayPointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[wayPointIndex];
    }

    private void Update()
    {
        Move();

        if(Vector3.Distance(transform.position, target.position) <= 0.3f )
        {
            SwitchTarget();
        }
    }

    private void SwitchTarget()
    {
        if (wayPointIndex >= Waypoints.points.Length-1)
        {
            Destroy(this.gameObject);
            return;
        }
        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    private void Move()
    {
        Vector3 direction = target.position - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
