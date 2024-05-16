using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNum : MonoBehaviour
{
    [Header("顯示現在的數字")]
    [SerializeField]    private Text Tnow;
    [SerializeField]    private Text Tsign;

    [Header("顯示目前儲存的數字")]
    [SerializeField]    private Text Tstore;
    //string Sstore; 移到GameDataManager

    //queue sign & number
    string nowNum;


    void Start(){
        deleteAll();
        clean();
    }

    
    void Update()
    {
        Tnow.text = string.Format("{0}",GameDataManager.Number);
        Tstore.text = string.Format(GameDataManager.Sstore);
    }

    public void sign(int S){
        switch(S){
            case 1: //+
                GameDataManager.sign = 1;
                Tsign.text = string.Format("+");
                break;
            case 2: //-
                GameDataManager.sign = 2;
                Tsign.text = string.Format("-");
                break;
        }
    }
    //刪除目前的輸入
    public void clean(){
        GameDataManager.Number = 0;
        sign(1);
        
    }
    //刪除所有暫存的輸入
    public void deleteAll(){
        GameDataManager.step.Clear();
        GameDataManager.ccNum.Clear();
        GameDataManager.Snow.Clear();
        GameDataManager.Sstore = "";
        GameDataManager.check = true;
        GameDataManager.changeCheck = false;
        for(int i = 0; i<GameDataManager.positionNum.Length ; i++){
            GameDataManager.positionNum[i] = 0;
        }
        GameObject.Find("UpDate").GetComponent<UpDate>().updateNum();
    }
    
    public void numInput(int num){
        GameDataManager.Number = GameDataManager.Number * 10 + num;
    }

    public void sendNum(){
        string ss = GameDataManager.Number.ToString();
        if(GameDataManager.sign == 1){
            GameDataManager.Sstore = GameDataManager.Sstore  + ss + "\n";

            for(int i = 0 ; i<ss.Length ; i++){
                int[] p = new int[]{ ss.Length -i -1, ss[i]-'0'};
                //Debug.Log(p[0] +" " + p[1]);
                GameDataManager.step.Enqueue(p);
            }
            ss = "+ " + ss;
            GameDataManager.Snow.Enqueue(ss);
        }
        else{
            GameDataManager.Sstore = GameDataManager.Sstore + Tsign.text + ss + "\n";
            for(int i = 0 ; i<ss.Length ; i++){
                int[] p = new int[]{ ss.Length -i -1, (ss[i]-'0')*-1 };
                //Debug.Log(p[0] +" " + p[1]);
                GameDataManager.step.Enqueue(p);
            }
            ss = "- " + ss;
            GameDataManager.Snow.Enqueue(ss);
        }
        clean();
    }
    //送出開始運作
    public void sendGame(){
        if( GameDataManager.autoPlay ){
            GameObject.Find("UpDate").GetComponent<UpDate>().numberCheck();
        }
        string ss = "計算結束";
        GameDataManager.Snow.Enqueue(ss);
    }
}
