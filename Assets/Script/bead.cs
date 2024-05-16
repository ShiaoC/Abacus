using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bead : MonoBehaviour
{
    
    public int digit;
    public int number;
    public float[] position = new float[3];
    private Vector2 target;

    int now = 0;
    float speed;

    void Start(){
        position[0] = GameDataManager.Yposition[ number%5 ];
        if(number == 0){
            position[1] = position[0]-0.7f;
        }
        else{
            position[1] = position[0]+0.7f;
        }
        target =new Vector2( transform.position.x, position[0]);
        speed = GameDataManager.speed;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    public void move(){
        int store = GameDataManager.positionNum[ digit ];
        store %= 10;
        if( store % 5 >= number && number != 0){
            if( now == 0 ){
                now = 1;
                target.y = position[now];
            }
        }
        else if(store >= 5 && number == 0){
            if( now == 0 ){
                now = 1;
                target.y = position[now];
            }
        }
        else{
            
                now = 0;
                target.y = position[now];
                
            //Debug.Log( digit+ " " + store);
        }
    }

}
