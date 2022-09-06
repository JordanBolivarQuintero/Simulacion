using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    [SerializeField] float mass = 1;

    [Range(0, 1)][SerializeField] float frictionCoefficient;
    [SerializeField] bool takeFluid = false;
    [Range(0, 1)][SerializeField] float damping = 1;
    [SerializeField] float gravity = -9.8f;

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        float weightMagnitude = mass * gravity;
        MyVector weight = new MyVector(0, weightMagnitude);

        MyVector friction = velocity.normalized * frictionCoefficient * -weightMagnitude * -1;

        acceleration *= 0f;

        ApplyForce(weight);
        ApplyForce(friction);

        if (takeFluid && position.y <= 0f)
        {
            float velocityMagnitude = velocity.magnitude;
            float frontalArea = transform.localScale.x;
            MyVector fluidFriction = velocity.normalized * frontalArea * velocityMagnitude * velocityMagnitude * -0.5f;
            ApplyForce(fluidFriction);
        }

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

        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
        }

        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
