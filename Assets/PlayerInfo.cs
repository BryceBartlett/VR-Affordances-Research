using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Used to maintain subject info between scenes
    private static string subject, age, hand, gender;

    public static string Subject
    {
        get
        {
            return subject;
        }
        set
        {
            subject = value;
        }
    }

    public static string Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }

    public static string Hand
    {
        get
        {
            return hand;
        }
        set
        {
            hand = value;
        }
    }

    public static string Gender
    {
        get
        {
            return gender;
        }
        set
        {
            gender = value;
        }
    }

    public static ArrayList Cubes_Reactions { get; set; }

    public static ArrayList Cubes_Reactions_2m { get; set; }
}
