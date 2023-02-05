using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThrowShuriken : MonoBehaviour
{
    [SerializeField] float timeCount=1,targetLocation=30, holdTime;
    [SerializeField] GameObject playerHand,playerGroundLocation;
    [SerializeField] GameObject GameManageObject;

    LineRenderer linRender;
    RunnerAnimation runnerAnimation;
    BoxCollider boxCollider;
    GameManageScript gameManageScript;
    TrailScript trailScript;
    
    float instantTime,AutoComeCount,delayTime;
    Vector3 tut1,tut2;
   [SerializeField] bool ThrowingFinish,ComeStart, returnComplete = false,notRepeat=true;
    bool autoComeBool1,autoComeBool2, newGameStart = false,waitForThrow=false;
  
    

    private void Start()
    {
        trailScript = playerGroundLocation.GetComponent<TrailScript>();
        gameManageScript = GameManageObject.GetComponent<GameManageScript>();
        boxCollider = transform.GetComponent<BoxCollider>();
        runnerAnimation = playerGroundLocation.GetComponent<RunnerAnimation>();
        instantTime = 0;
        linRender = transform.GetComponent<LineRenderer>();
        delayTime = 1f;
        ThrowingFinish = true;
        returnAxeCompleted();
    }
    private void Update()
    {
        if (!gameManageScript.getGameEnd()) 
        {
            if (!newGameStart)
            {
                linRender.enabled = true;
                boxCollider.enabled = true;
                newGameStart = true;
                holdTime = 0;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if ( notRepeat && ThrowingFinish && delayTime<0)
                        {
                            runnerAnimation.setTriggerAxeCatch();
                            autoComeBool2 = false;
                            notRepeat = false;
                            delayTime = 0.5f;
                        }

                        break;
                        

                    case TouchPhase.Stationary:
                    case TouchPhase.Moved:
                        if (notRepeat && ThrowingFinish && delayTime < 0)
                        {
                            runnerAnimation.setTriggerAxeCatch();
                            autoComeBool2 = false;
                            notRepeat = false;
                            delayTime = 0.5f;
                        }
                        if (holdTime < 20 )
                            holdTime += 35f*Time.deltaTime;

                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:

                        if (returnComplete && ThrowingFinish && delayTime < 0)
                        {
                            waitForThrow = false;
                            runnerAnimation.setTriggerAxeThrow();
                            AutoComeCount=2f;
                            autoComeBool2 = true;
                            notRepeat = true;
                            delayTime =0.5f;
                        }

                        break;
                }
            }

            if (AutoComeCount > 0)
            {
                AutoComeCount -= Time.deltaTime;
            }
            else
            {
                if (autoComeBool2)
                {
                    autoComeBool1 = true;
                }
            }
            if (autoComeBool1)
            {
                runnerAnimation.setTriggerAxeCatch();
                notRepeat = false;
                autoComeBool1 = false;
                autoComeBool2 = false;
            }

            if (returnComplete && linRender.enabled && linRender.positionCount==2)
            {
                linRender.SetPosition(0, playerGroundLocation.transform.position + Vector3.up * 0.1f);
                linRender.SetPosition(1, playerGroundLocation.transform.position + (targetLocation + holdTime) * Vector3.forward + Vector3.up * 0.1f);
            }
        }
        else
        {
            linRender.enabled = false;
            newGameStart = false;
        }

        if (!ThrowingFinish)
        {
            ShurikenThrowing(tut2);
        }

        if (ComeStart)
        {
            ShurikenComingBack();
        }

        if (delayTime >= 0)
        {
            delayTime -= Time.deltaTime;
        }
    }
    
    //coming
    public void AxeCome()
    {
        ComeStart = true;
        tut1 = transform.position;
        instantTime = 0f;
    }

    void ShurikenComingBack()
    {
        if (instantTime <= timeCount)
        {
            transform.position = QuadraticCurve(tut1, playerHand, instantTime / timeCount);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-40, 90, instantTime * 1000), instantTime / timeCount);
        }
        else
        {
            returnAxeCompleted();
            linRender.positionCount = 2;
            holdTime = 0;
            ComeStart = false;
        }
    }

    public void returnAxeCompleted()
    {
        ThrowingFinish = true;
        returnComplete = true;
        transform.parent = playerHand.transform;
        transform.position = new Vector3(transform.parent.transform.position.x - 0.0002191619f, transform.parent.transform.position.y - 0.0003755888f, transform.parent.transform.position.z);
        transform.localEulerAngles = new Vector3(-104, 68, -6);
        boxCollider.enabled = false;
    }
    //----------------------------------------------

    //throwing
    public void ThrowAxeAnimationEvent()
    {
        boxCollider.enabled = true;
        linRender.positionCount = 0;
        instantTime = 0;
        tut2 = playerHand.transform.position;
        ThrowingFinish = false;
        returnComplete = false;
    }

    void ShurikenThrowing(Vector3 tut)
    {
        transform.parent = null;
        instantTime += Time.deltaTime;
        transform.position = Vector3.Lerp(playerHand.transform.position,tut +(targetLocation+holdTime)*Vector3.forward-Vector3.up*tut.y+Vector3.up*0.01f, instantTime / timeCount);
        transform.rotation = Quaternion.Lerp(playerHand.transform.rotation,Quaternion.Euler(-90,90,instantTime*1000), instantTime / timeCount);
        
        if (tut + (targetLocation + holdTime) * Vector3.forward - Vector3.up * tut.y + Vector3.up * 0.01f == transform.position)
        {
            ThrowingFinish = true;
            waitForThrow = true;
        }
    }
    public bool getCheckFinishThrowing() 
    {
        return waitForThrow;
    }
    //------------------------------------------------

    Vector3 QuadraticCurve(Vector3 target, GameObject player, float t)
    {
        instantTime += Time.deltaTime;
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 P2 = player.transform.position;
        Vector3 curvePoint = target.z*Vector3.forward + player.transform.position.x*Vector3.right+player.transform.position.y*Vector3.up;

        Vector3 returnValue= (uu * target) + (2 * u * t * curvePoint) + (tt * P2);

        return returnValue;

       
    }
}
