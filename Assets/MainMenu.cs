using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    static string age;
    static string subject;
    static string hand;
    static string gender;
    public GameObject input_field_age;
    public GameObject input_field_subject;
    public GameObject input_field_hand;
    public GameObject input_field_gender;



    public void PlayGame() 
    {
        GrabInput();
        bool status = Int32.TryParse(subject, out int result);
        if (!status) 
        {
            GameObject warning = GameObject.Find("warn");
            warning.GetComponent<Text>().text = "Please enter a number as the Subject";
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GrabInput() 
    {
        age = input_field_age.GetComponent<Text>().text;
        subject = input_field_subject.GetComponent<Text>().text;
        hand = input_field_hand.GetComponent<Text>().text;
        gender = input_field_gender.GetComponent<Text>().text;
        PlayerInfo.Age = age;
        PlayerInfo.Subject = subject;
        PlayerInfo.Hand = hand;
        PlayerInfo.Gender = gender;
        PlayerInfo.Cubes_Reactions = new ArrayList();
        PlayerInfo.Cubes_Reactions_2m = new ArrayList();
    }
}
