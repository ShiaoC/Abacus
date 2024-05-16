using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserCommand : MonoBehaviour{

    [SerializeField] GameObject nextButton;

    public void AutoPlay(bool check){
        GameDataManager.autoPlay = check;
        Debug.Log(GameDataManager.autoPlay);
        nextButton.SetActive(!GameDataManager.autoPlay);
    }

    public void nextStep(){
        GameObject.Find("UpDate").GetComponent<UpDate>().numberCheck();
    }
}
