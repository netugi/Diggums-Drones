using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform movePoint;
    public Vector3 nextPos;

    
    private GameObject obs;
    public string nextlvl;

    private float facingDirection;


    void Start()
    {
        
        nextPos = movePoint.transform.position;
        movePoint.parent = null;
       
    }

    public void Move(){
        string LuaSequence = LuaManager.GenerateLuaSequence();
        Debug.Log(LuaSequence);
        StartCoroutine(StartDrone(LuaSequence));
        
    }

    IEnumerator StartDrone(string sequence){
        int seqlen = sequence.Length;
        for (int i = 0; i < seqlen; i++){
            if(facingDirection == 360 || facingDirection == -360) facingDirection = 0;
            NextMove(sequence[i]);
            movePoint.transform.position = nextPos;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void NextMove(char seq){
        Debug.Log(seq);
        if(seq == 'f'){
            forward();
        }
        else if(seq == 'l')
        {
            turnLeft();       
        }
        else if(seq == 'r'){
            turnRight();
        }
        else if(seq == 'd'){
            digInfront();
        }
        
    }


    //moves forward to the facing direction
    void forward(){

        string tempface = checkFacingDirection();

        if (tempface == "forward") //facing front
        {
            nextPos.z += 1;
            
        }
        else if(tempface == "right") //facing right
        {
            nextPos.x += 1f;

        }
        else if (tempface == "left" ) //facing left
        {
            nextPos.x -= 1f;
        }
        else if(tempface == "back") //facing back
        {
            nextPos.z -= 1f;
        }

    }



    //Rotates drone to the right
    void turnRight(){
        facingDirection += 90;
        transform.Rotate(0,90,0,Space.World);
    }

    //rotates drone to the left
    void turnLeft(){
        facingDirection -= 90;
        transform.Rotate(0,-90,0,Space.World);
        Debug.Log(facingDirection);
    }

    // void goUp(){
    //     dronepos.y += 1f;
    //     transform.position = dronepos;
    // }
    // void goDown(){
    //     if(dronepos.y <= 0.5) Debug.Log("cannot go lower");
    //     else {
    //         dronepos.y -= 1;
    //         transform.position = dronepos;
    //     }
    // }

    void digInfront(){
        
        if(datamanager.obstacleType == "diggable")
        {   
            
            StartCoroutine(digeffect());
            
        }else
        {
            Debug.Log("obstacle is not diggable");
        }
    }

    IEnumerator digeffect(){
            obs = datamanager.obstacle;
            obs.GetComponent<Renderer>().material.color = Color.green;
            yield return new WaitForSeconds(0.2f);
            obs.GetComponent<Renderer>().material.color = Color.black;
            yield return new WaitForSeconds(0.2f);
            obs.GetComponent<Renderer>().material.color = Color.green;
            yield return new WaitForSeconds(0.2f);
            obs.GetComponent<Renderer>().material.color = Color.black;
            yield return new WaitForSeconds(0.2f);
            Destroy(obs);
    }

    void OnCollisionEnter(Collision other)
   {
       
       if(other.gameObject.tag == "Finish"){
           FinishLevel(nextlvl);
       }
        
   }    

   void FinishLevel(string _scene){
       SceneManager.LoadScene(_scene);
   }

    string checkFacingDirection(){
         if (facingDirection == 0) //facing front
        {
            return "forward";
            
        }
        else if(facingDirection == 90 || facingDirection == -270) //facing right
        {
            return "right";

        }
        else if (facingDirection == -90 || facingDirection == 270 ) //facing left
        {
            return "left";
        }
        else //facing back
        {
            return "back";
        }
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        
    }
}
