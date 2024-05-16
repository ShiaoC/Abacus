using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDate : MonoBehaviour{

    [Header("顯示現在的數字")]
    [SerializeField]    private Text Tnow;
    //bool changeCheck;  移到GDM

    void Start()
    {
        GameDataManager.beads = GameObject.FindGameObjectsWithTag("bead");
        //c();
    }

    public void updateNum(){
        foreach (GameObject bead in GameDataManager.beads){
            bead.GetComponent<bead>().move();
        }
        if(GameDataManager.Snow.Count !=0){
            Tnow.text = string.Format( (string)GameDataManager.Snow.Peek() );
        }
        
    }

    public void numberCheck(){
        int[] addNum;
        int fromNum;

        if( GameDataManager.check ){
            if(GameDataManager.changeCheck){
                GameDataManager.Snow.Dequeue();
            }
            addNum = (int[])GameDataManager.step.Dequeue();

            if(addNum[0] == 0)  GameDataManager.changeCheck = true;
            else    GameDataManager.changeCheck = false;
        }
        else{
            addNum = (int[])GameDataManager.ccNum.Pop();
        }
        //Debug.Log(GameDataManager.positionNum[3]+""+GameDataManager.positionNum[2]+""+GameDataManager.positionNum[1]+""+GameDataManager.positionNum[0]);
        //Debug.Log(addNum[0]);
        fromNum = GameDataManager.positionNum[ addNum[0] ]%10;


        //需要借位
        if( GameDataManager.positionNum[ addNum[0] ] + addNum[1] < 0){
            while( GameDataManager.positionNum[ addNum[0] ] + addNum[1] < 0){
                //Debug.Log("借位");
                GameDataManager.check = false;
                int[] p = new int[]{ addNum[0] , addNum[1]+10 };
                GameDataManager.ccNum.Push(p);

                addNum[0] = addNum[0]+1;
                addNum[1] = -1;
            }
            int[] dp = new int[]{ addNum[0] , addNum[1] };
            GameDataManager.ccNum.Push(dp);
            numberCheck();
        }
        else{
            GameDataManager.positionNum[ addNum[0] ] += addNum[1];
            updateNum();

            //需要進位
            if( GameDataManager.positionNum[ addNum[0] ] >= 10 ){
                //Debug.Log("進位");
                GameDataManager.check = false;
                GameDataManager.positionNum[ addNum[0] ] -=10;
                int[] p = new int[]{ addNum[0]+1 , 1 };
                GameDataManager.ccNum.Push(p);
            }
            else if( GameDataManager.ccNum.Count ==0 ){ //可以正常計算
                GameDataManager.check = true;
            }

            Debug.Log(GameDataManager.positionNum[3]+""+GameDataManager.positionNum[2]+""+GameDataManager.positionNum[1]+""+GameDataManager.positionNum[0]);
            GameObject.Find("Hand").GetComponent<HandAnime>().handAnime(fromNum, GameDataManager.positionNum[ addNum[0] ]%10, addNum[0]);

            if( (GameDataManager.step.Count != 0 || !GameDataManager.check ) && GameDataManager.autoPlay  ){
                Invoke("numberCheck",GameDataManager.updateTime);
            }
            else if(GameDataManager.step.Count == 0 && GameDataManager.check){
                GameDataManager.Snow.Dequeue();
                updateNum();
            }
            //Debug.Log("F"+fromNum +"  T"+GameDataManager.positionNum[ addNum[0] ]%10);
        }
        

        
        

        
        
    }


}
