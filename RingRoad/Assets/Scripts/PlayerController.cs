using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public GameObject particle;

    public float speed;

    private bool isMoving;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.Rotate(0, 0, speed);
        }
        else
        {
            transform.Rotate(0, 0, -speed);
        }
    }

    public void RevertRotation()
    {
        isMoving = !isMoving;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        particle.SetActive(true);
    //        Destroy(this);
    //    }
    //}
}
