using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AABB : MonoBehaviour
{

    private float half = 0.5f;
    public AABB[] asteroid;
    private GameObject player;
    private bool collidedX = false;
    private bool collidedY = false;


    private void Start()
    {


        

    }

    void Update()
    {

        DrawBox();
    }

    void FixedUpdate()
    {

        DetectCollisions();

    }

    void DrawBox()
    {



        //Controls Top Line 
        Debug.DrawLine(new Vector3(((GetCenter().x) - (half * GetLength().x)), (GetCenter().y + ((GetLength().y * half))), 0), new Vector3(((GetCenter().x + (GetLength().x * half))), ((GetCenter().y + (GetLength().y * half))), 0), Color.white);

        //    //Controls Left Side
        Debug.DrawLine(new Vector3(((GetCenter().x) - (half * GetLength().x)), (GetCenter().y + ((GetLength().y * half))), 0), new Vector3((GetCenter().x - (GetLength().x * half)), ((GetCenter().y - (GetLength().y * half))), 0), Color.white);

        //    //Controls Bottom Side
        Debug.DrawLine(new Vector3((GetCenter().x - (GetLength().x * half)), ((GetCenter().y - (GetLength().y * half))), 0), new Vector3((GetCenter().x + (GetLength().x * half)), (GetCenter().y - (GetLength().y * half)), 0), Color.white);

        //    //Controls Right Side
        Debug.DrawLine(new Vector3((GetCenter().x + (GetLength().x * half)), (GetCenter().y - (GetLength().y * half)), 0), new Vector3(((GetCenter().x + (GetLength().x * half))), ((GetCenter().y + (GetLength().y * half))), 0), Color.white);

    }


    public Vector2 GetCenter()
    {

        return transform.position;
    }


    public Vector2 GetLength()

    {

        var spriteLength = GetComponent<SpriteRenderer>();
        return spriteLength.size;


    }


    void DetectCollisions​()

    {
        asteroid = GameObject.FindObjectsOfType<AABB>();


        for (int i = 0; i < asteroid.Length; i++)
        {
            if ( (this != asteroid[i]) &&
                ((this.GetCenter().x + (GetLength().x * half)) <= (asteroid[i].GetCenter().x - (GetLength().x * half))) &&
               ((this.GetCenter().x - (GetLength().x * half)) >= (asteroid[i].GetCenter().x + (GetLength().x * half))))
            {
                 collidedX = true;
                
            }
            if ((this != asteroid[i]) &&
                ((this.GetCenter().y + (GetLength().y * half)) <= (asteroid[i].GetCenter().y - (GetLength().y * half))) &&
                ((this.GetCenter().y - (GetLength().y * half)) >= (asteroid[i].GetCenter().y + (GetLength().y * half))))
            {
                collidedY = true;
               
            }

            if (!(collidedY && collidedX) )
            {
                Debug.Log(" x & y collision");
               
            }
        }

    }
}


   
    




