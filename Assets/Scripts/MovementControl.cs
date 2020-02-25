using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonSharp.Interpreter;

public class MovementControl : MonoBehaviour
{
    public GameObject drone;
    Vector3 dronepos;
    float facingDirection; //stores where the drone is facing by angle


    //moves one block towards the drone facing.
    void forward(){

        if (facingDirection == 0) {
            dronepos.z += 1f * Time.deltaTime;
            drone.transform.position = dronepos;
        }
        else if(facingDirection == 90 || facingDirection == -270){
            dronepos.x += 1f;
            drone.transform.position = dronepos;
        }
        else if (facingDirection == -90 || facingDirection == 270 ){
            dronepos.x -= 1f;
            drone.transform.position = dronepos;
        }
        else if(facingDirection == 180 || facingDirection == -180){
            dronepos.z -= 1f;
            drone.transform.position = dronepos;
        }
    }

    //Rotates drone to the right
    void turnRight(){
        facingDirection += 90;
        
        drone.transform.Rotate(0,90,0,Space.World);
    }

    //rotates drone to the left
    void turnLeft(){
        facingDirection -= 90;
        drone.transform.Rotate(0,-90,0,Space.World);
        Debug.Log(facingDirection);
    }

    void goUp(){
        dronepos.y += 1f;
        drone.transform.position = dronepos;
    }
    void goDown(){
        if(dronepos.y <= 0.5) Debug.Log("cannot go lower");
        else {
            dronepos.y -= 1;
            drone.transform.position = dronepos;
        }
    }
    public void Move(string sequence){
    if(facingDirection == 360 || facingDirection == -360) facingDirection = 0;

        switch (sequence)
        {
            case "f":
                forward();
                break;
            case "r":
                turnRight();
                break;
            case "l":
                turnLeft();
                break;
            case "u":
                goUp();
                break;
            case "n":
                goDown();
                break;
            default: break;
        }
    }


    void Start()
    {
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        dronepos = drone.transform.position; //stores the location of the drone
    }


}
