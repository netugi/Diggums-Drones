using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Generator : MonoBehaviour
{
   public Terrain terrain;
    Vector3 pos = new Vector3(-0.5f,0.5f,-0.5f);
    public Material dirt;
    float xpos = -0.5f;
    float ypos = -0.5f;
    int[,] plane = new int[,]
    {
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},

    };


    



    void BuildTerrain(){
        
        GameObject cube;

        for(int x = 0; x < 21; x++){
            for(int y = 0; y < 21; y++){
                if(plane[x,y] == 1){
                    cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.parent = terrain.transform;
                    cube.GetComponent<MeshRenderer>().material = dirt;
                    pos.x = (float)(x + 0.5);
                    pos.z = (float)(y + 0.5);
                    cube.transform.position = pos;
                }
            }
        }
        
    
        // for (int x = 0; x < 21; x++)
        // {
        //     if(((pos.x > 6.5f && pos.x < 14.5f) && (pos.z > -0.5f && pos.z < 5.5f))){

        //         cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //         cube.transform.parent = terrain.transform;
        //         cube.transform.position = pos;
        //         pos.x += 1.0f;
        //     }
        //     //else pos.x += 1.0f;

        //     for (int y = 0; y < 21; y++)
        //     {
        //         if(((pos.x > 6.5f && pos.x < 14.5f) && (pos.z > -0.5f && pos.z < 5.5f))){

        //         cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //         cube.transform.parent = terrain.transform;
        //         pos.z += 1.0f;
        //         cube.transform.position = pos;
                
        //     }
        //     else {
        //         pos.z += 1.0f;
        //     }

        //     }
        //     pos.z = -0.5f;
        // }

        
        

    }

    



    void Start()
    {
        BuildTerrain();
    }

}
