using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newton : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;
    
    [SerializeField] float mass = 1;
    [SerializeField] newton mass2;

    [Range(0, 1)][SerializeField] float damping = 1;
    [SerializeField] float gravity = -9.8f;

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        MyVector r = mass2.transform.position - transform.position;

        float rMagnitude = r.magnitude;
        MyVector force = r.normalized * (1 / mass2.mass * mass / rMagnitude * rMagnitude);

        float weightMagnitude = mass * gravity;
        MyVector weight = new MyVector(0, weightMagnitude);
        acceleration *= 0f;

        ApplyForce(force);
        Move();
    }

    void Update()
    {

    }
    void Move()
    {
        /*print("acceleration = " + acceleration);
        print("velocity = " + velocity);
        print("position = " + position);*/

        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.magnitude >= 3f)
        {
            velocity.Normalize();
            velocity *= 3;
        }
        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
