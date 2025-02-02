﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JStick : MonoBehaviour
{

    private bool touchStart;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector3 inputVector;

    public Transform circle;
    public Transform outerCircle;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
 
            //circle.transform.position = pointA * -1;
            //outerCircle.transform.position = pointA * -1;
            //circle.GetComponent<SpriteRenderer>().enabled = true;
            //outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);

            //circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            //circle.GetComponent<SpriteRenderer>().enabled = false;
            //outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    void moveCharacter(Vector3 direction)
    {
        inputVector = direction;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");


    }
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}
