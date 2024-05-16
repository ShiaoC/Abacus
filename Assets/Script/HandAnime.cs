using System.Collections;
using System.Collections.Generic;
using UnityEngine;



        // Finger 1大拇指  2食指  3兩隻     -1 idle

        // UD    up=0   down=1   in=2   out=3   (in/out 只有兩隻手指頭才有用)

        // number 0(上面那排) 1234(由上到下)

public class HandAnime : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject[] position;
    float[] positionX = new float[10];
    [SerializeField] GameObject hand;
    Transform T;
    float center;
    int centerPosition = 0;
    void Start(){
        animator = GetComponent<Animator>();
        T = hand.GetComponent<Transform>();
        center = T.position.x;
        for(int i = 0; i<position.Length ; i++){
            positionX[i] = position[i].GetComponent<Transform>().position.x;
        }
    }

    public void handAnime(int from, int to, int digit){
        T.position = new Vector3( center + (positionX[digit]-positionX[centerPosition]), T.position.y,0);
        Debug.Log(T.position.x +" "+T.position.y);
        //position[0].GetComponent<Transform>().position =new Vector3( center + (positionX[digit]-positionX[centerPosition]), transform.position.y,0);


        //完全沒變化
        //Debug.Log(from+" "+to);//////////////////////////////////////////
        if(from == to){
            //animator.SetInteger ("Finger", -1);
            play(0);
        }
        
        //只撥5的狀況    Finger=2
        else if(from%5 == to%5){
            //animator.SetInteger("Finger", 2);
            //Debug.Log("只動5");//////////////////////////////////////////
            // + 往下
            if(from < to){
                /*animator.SetInteger ("UD", 1);
                animator.SetInteger ("number", 0);*/
                play(6);
            }
            // - 往上
            else{
                //animator.SetInteger ("UD", 0);
                play(5);
            }
        }

        //只撥底下的狀況
        else if( (0<=from && from<=4 && 0<=to && to<=4) || (5<=from && from<=9 && 5<=to && to<=9) ){
            //食指
            if(from > to){
                /*animator.SetInteger ("Finger", 2);
                animator.SetInteger ("UD", 1);
                animator.SetInteger ("number", (to%5)+1 );*/
                //7~10
                play((to%5)+7);
                //Debug.Log((to%5)+1);//////////////////////////////////////////
            }
            //大拇指
            else{
                /*animator.SetInteger ("Finger", 1);
                animator.SetInteger ("UD", 0);
                animator.SetInteger ("number", to%5);*/
                //1~4
                play(to%5);
                //Debug.Log(to%5);//////////////////////////////////////////
            }
        }

        //會用到兩隻手指頭
        else{
            //animator.SetInteger ("Finger", 3);
            //up-0
            if(from > to && from%5 < to%5){
                /*animator.SetInteger ("UD", 0);
                animator.SetInteger ("number", to%5);*/
                //11-14
                play(to%5 +10);
            }
            //down-1
            else if( from < to && from%5 > to%5){
                /*animator.SetInteger ("UD", 1);
                animator.SetInteger ("number", (to%5)+1 );*/
                //15-18
                play(to%5 +15);
            }
            //in-2
            else if( from < to ){
                /*animator.SetInteger ("UD", 2);
                animator.SetInteger ("number", to%5 );*/
                //19-22
                play(to%5 +18);
            }
            //out-3
            else{
                /*animator.SetInteger ("UD", 3);
                animator.SetInteger ("number", (to%5)+1 );*/
                //23-26
                play(to%5 +23);
            }
        }
        //play();
        //animator.SetBool ("", true);
    }

    void play(int n){
        animator.SetInteger ("check", n);
        animator.SetTrigger ("Play");
        // Finger 1大拇指  2食指  3兩隻     -1 idle

        // UD    up=0   down=1   in=2   out=3   (in/out 只有兩隻手指頭才有用)

        // number 0(上面那排) 1234(由上到下)
    }
}
