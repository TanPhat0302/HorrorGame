using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    public static int PlayerHealth = 100;
    public static bool HealthChanged = false;
    public static float BatteryPower = 1.0f;
    public static bool BatteryRefill = false;
    public static bool FlashLightOn = false;
    public static bool NVLightOn = false;
    public static int Apples = 0;
    public static int Batteries = 0;
    public static bool Knife = false;
    public static bool Axe = false;
    public static bool Bat = false;
    public static bool Gun = false;
    public static bool Crossbow = false;
    public static bool Housekey = false;
    public static bool Roomkey = false;
    public static bool Cabinkey = false;
    public static int Ammos = 0;
    public static bool Arrows = false;
    public static bool NewGame = false;

    private void Start()
    {
        if(NewGame == true)
        {
        PlayerHealth = 100;
        HealthChanged = false;
        BatteryPower = 1.0f;
        BatteryRefill = false;
        FlashLightOn = false;
        NVLightOn = false;
        Apples = 0;
        Batteries = 0;
        Knife = false;
        Axe = false;
        Bat = false;
        Gun = false;
        Crossbow = false;
        Housekey = false;
        Roomkey = false;
        Cabinkey = false;
        Ammos = 0;
        Arrows = false;
        }
    }

}

