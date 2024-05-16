using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    //[SerializeField] 
    public static float[] Yposition = new float[] {0.66f, -1.45f, -2.11f, -2.8f, -3.4f};
    public static float Number = 28;//原數
    
    public static int[] positionNum = new int[] {0,0,0,0,0,0,0,0}; //個 十 百 千
    public static int sign = 0; //0無  1加  2減  3乘  4除
    public static Queue step = new Queue(); //0位置 1加減多少
    public static bool check = true;// T=正常  F=需要進位/退位
    public static Stack ccNum = new Stack(); //0位置 1加減多少

    public static string Sstore;
    public static Queue Snow = new Queue();//顯示現在加到多少
    public static bool changeCheck;

    public static float speed = 1f;
    public static float updateTime = 2f;

    public static GameObject[] beads;


    //使用者選項
    public static bool autoPlay = true;
}
