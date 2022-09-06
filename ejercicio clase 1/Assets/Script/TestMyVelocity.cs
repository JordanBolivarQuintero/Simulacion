using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVelocity : MonoBehaviour
{
    [SerializeField] private MyVector position_;
    private MyVector displaicement;
    [SerializeField] private MyVector velocity;

    void Start()
    {
        position_ = new MyVector(transform.position.x, transform.position.y);
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        displaicement = velocity * Time.deltaTime;  
        position_ += displaicement;

        if (Mathf.Abs(position_.x) >= 5)
        {
           velocity.x *= -1;
        }
        if (Mathf.Abs(position_.y) >= 5)
        {
            velocity.y *= -1;
        }

        transform.position = position_;
    }
}
