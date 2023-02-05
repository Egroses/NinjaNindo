using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    [SerializeField] float swerveLimit=4.5f,speed=5,sensivity=2;
    float lastLocation, distance;
    
    RunnerAnimation runnerAnimation;
    bool runCan;
    private void Start()
    {
        runnerAnimation = transform.GetComponent<RunnerAnimation>();
        runCan = true;
    }

    void Update()
    {
        if (!GameManageScript.Instance.getGameEnd())
        {
            if (runCan)
            {
                runnerAnimation.setBoolRunOn();
                runCan = false;
            }
            Swerve();
            Move();
        }
        else
        {
            runnerAnimation.setBoolRunOff();
            runCan = true;
        }
    }

    void Swerve()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    lastLocation = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    distance = lastLocation - touch.position.x;
                    distance = Mathf.Clamp(distance * Time.deltaTime, -1, +1);
                    lastLocation = touch.position.x;
                    break;
                case TouchPhase.Stationary:
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    distance = 0;
                    break;
            }
        }
    }

    void Move()
    {
        if(transform.position.x - Vector3.right.x * distance*sensivity<swerveLimit && transform.position.x - Vector3.right.x * distance*sensivity > -swerveLimit)
            transform.position -=Vector3.right* distance*sensivity;
        transform.position +=Vector3.forward * Time.deltaTime * speed;
    }
    public void ResetPositionPlayer()
    {
        transform.position = Vector3.zero;
    }
}
