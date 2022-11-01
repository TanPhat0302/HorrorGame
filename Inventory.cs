using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    private bool InventoryActive = false;
    private AudioSource MyPlayer;


    [SerializeField] AudioClip AppleBite;
    [SerializeField] AudioClip BatteryChange;
    [SerializeField] AudioClip WeaponChange;
    [SerializeField] GameObject PlayerArms;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Bat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject Crossbow;


    //Weapon
    [SerializeField] GameObject BatImage;
    [SerializeField] GameObject BatButton;
    [SerializeField] GameObject KnifeImage;
    [SerializeField] GameObject KnifeButton;
    [SerializeField] GameObject GunImage;
    [SerializeField] GameObject GunButton;
    [SerializeField] GameObject AxeImage;
    [SerializeField] GameObject AxeButton;
    [SerializeField] GameObject CrossbowImage;
    [SerializeField] GameObject CrossbowButton;
    //Ammo and Arrow
    [SerializeField] GameObject AmmoImage1;
    [SerializeField] GameObject AmmoButton1;
    [SerializeField] GameObject AmmoImage2;
    [SerializeField] GameObject AmmoButton2;
    [SerializeField] GameObject AmmoImage3;
    [SerializeField] GameObject AmmoButton3;
    [SerializeField] GameObject AmmoImage4;
    [SerializeField] GameObject AmmoButton4;
    [SerializeField] GameObject ArrowImage;
    [SerializeField] GameObject ArrowButton;

    //Key
    [SerializeField] GameObject HousekeyImage;
    [SerializeField] GameObject HousekeyButton;
    [SerializeField] GameObject RoomkeyImage;
    [SerializeField] GameObject RoomkeyButton;
    [SerializeField] GameObject CabinkeyImage;
    [SerializeField] GameObject CabinkeyButton;

    //Apples
    [SerializeField] GameObject AppleImage1;
    [SerializeField] GameObject AppleButton1;
    [SerializeField] GameObject AppleImage2;
    [SerializeField] GameObject AppleButton2;
    [SerializeField] GameObject AppleImage3;
    [SerializeField] GameObject AppleButton3;
    [SerializeField] GameObject AppleImage4;
    [SerializeField] GameObject AppleButton4;
    [SerializeField] GameObject AppleImage5;
    [SerializeField] GameObject AppleButton5;
    [SerializeField] GameObject AppleImage6;
    [SerializeField] GameObject AppleButton6;


    // Batteries
    [SerializeField] GameObject BatteryImage1;
    [SerializeField] GameObject BatteryButton1;
    [SerializeField] GameObject BatteryImage2;
    [SerializeField] GameObject BatteryButton2;
    [SerializeField] GameObject BatteryImage3;
    [SerializeField] GameObject BatteryButton3;
    [SerializeField] GameObject BatteryImage4;
    [SerializeField] GameObject BatteryButton4;

    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);

        //Apple icon 
        AppleImage1.gameObject.SetActive(false);
        AppleButton1.gameObject.SetActive(false);
        AppleImage2.gameObject.SetActive(false);
        AppleButton2.gameObject.SetActive(false);
        AppleImage3.gameObject.SetActive(false);
        AppleButton3.gameObject.SetActive(false);
        AppleImage4.gameObject.SetActive(false);
        AppleButton4.gameObject.SetActive(false);
        AppleImage5.gameObject.SetActive(false);
        AppleButton5.gameObject.SetActive(false);
        AppleImage6.gameObject.SetActive(false);
        AppleButton6.gameObject.SetActive(false);

        //Ammo and Arrow
        AmmoImage1.gameObject.SetActive(false);
        AmmoButton1.gameObject.SetActive(false);
        AmmoImage2.gameObject.SetActive(false);
        AmmoButton2.gameObject.SetActive(false);
        AmmoImage3.gameObject.SetActive(false);
        AmmoButton3.gameObject.SetActive(false);
        AmmoImage4.gameObject.SetActive(false);
        AmmoButton4.gameObject.SetActive(false);
        ArrowImage.gameObject.SetActive(false);
        ArrowButton.gameObject.SetActive(false);


        //Batteries
        BatteryImage1.gameObject.SetActive(false);
        BatteryButton1.gameObject.SetActive(false);
        BatteryImage2.gameObject.SetActive(false);
        BatteryButton2.gameObject.SetActive(false);
        BatteryImage3.gameObject.SetActive(false);
        BatteryButton3.gameObject.SetActive(false);
        BatteryImage4.gameObject.SetActive(false);
        BatteryButton4.gameObject.SetActive(false);


        //Weapon
        BatImage.gameObject.SetActive(false);
        BatButton.gameObject.SetActive(false);
        AxeImage.gameObject.SetActive(false);
        AxeButton.gameObject.SetActive(false);
        GunImage.gameObject.SetActive(false);
        GunButton.gameObject.SetActive(false);
        CrossbowImage.gameObject.SetActive(false);
        CrossbowButton.gameObject.SetActive(false);
        KnifeImage.gameObject.SetActive(false);
        KnifeButton.gameObject.SetActive(false);
     

        //Key
        RoomkeyImage.gameObject.SetActive(false);
        RoomkeyButton.gameObject.SetActive(false);
        HousekeyImage.gameObject.SetActive(false);
        HousekeyButton.gameObject.SetActive(false);
        CabinkeyImage.gameObject.SetActive(false);
        CabinkeyButton.gameObject.SetActive(false);

        InventoryActive = false;
        Cursor.visible = false;
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive == false)
            {

                InventoryActive = true;
                InventoryMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;

            }
            else if (InventoryActive == true)
            {

                InventoryActive = false;
                InventoryMenu.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.visible = false;

            }

        }
        CheckInventory();
        CheckWeapons();
        CheckKeys();
        CheckAmmos();
        CheckArrow();
    }
    void CheckInventory()
    {   //Apples
        if (SaveScript.Apples == 0)
        {
            AppleImage1.gameObject.SetActive(false);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(false);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);

        }
        if (SaveScript.Apples == 1)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(true);
            AppleImage2.gameObject.SetActive(false);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);



        }
        if (SaveScript.Apples == 2)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(true);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);

        }
        if (SaveScript.Apples == 3)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(true);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);


        }
        if (SaveScript.Apples == 4)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(true);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 5)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(true);
            AppleButton5.gameObject.SetActive(true);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 6)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(true);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(true);
            AppleButton6.gameObject.SetActive(true);
        }

        //Batteries
        if (SaveScript.Batteries == 0)
        {
            BatteryImage1.gameObject.SetActive(false);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(false);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);

        }
        if (SaveScript.Batteries == 1)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(true);
            BatteryImage2.gameObject.SetActive(false);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }

        if (SaveScript.Batteries == 2)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(true);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 3)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(true);
            BatteryButton3.gameObject.SetActive(true);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 4)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(true);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(true);
            BatteryButton4.gameObject.SetActive(true);
        }

    }

    void CheckKeys() //Key
    {
        if (SaveScript.Housekey == true)
        {
            HousekeyImage.gameObject.SetActive(true);
            HousekeyButton.gameObject.SetActive(true);
        }

        if (SaveScript.Roomkey == true)
        {
            RoomkeyImage.gameObject.SetActive(true);
            RoomkeyButton.gameObject.SetActive(true);
        }

        if (SaveScript.Cabinkey == true)
        {
            CabinkeyImage.gameObject.SetActive(true);
            CabinkeyButton.gameObject.SetActive(true);
        }
    }
    void CheckWeapons() //weapon
    {
        if (SaveScript.Knife == true)
        {
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
        }
        if (SaveScript.Bat == true)
        {
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
        }
        if (SaveScript.Gun == true)
        {
            GunImage.gameObject.SetActive(true);
            GunButton.gameObject.SetActive(true);
        }
        if (SaveScript.Axe == true)
        {
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
        }
        if (SaveScript.Crossbow == true)
        {
            CrossbowImage.gameObject.SetActive(true);
            CrossbowButton.gameObject.SetActive(true);
        }
    }

    void CheckArrow() //Arrow
    {
        if (SaveScript.Arrows == false)
        {
            ArrowImage.gameObject.SetActive(false);
            ArrowButton.gameObject.SetActive(false);
        }
        if (SaveScript.Arrows == true)
        {
            ArrowImage.gameObject.SetActive(true);
            ArrowButton.gameObject.SetActive(true);
        }
    }
    void CheckAmmos() //Ammo
    {
        if (SaveScript.Ammos == 0)
        {
            AmmoImage1.gameObject.SetActive(false);
            AmmoButton1.gameObject.SetActive(false);
            AmmoImage2.gameObject.SetActive(false);
            AmmoButton2.gameObject.SetActive(false);
            AmmoImage3.gameObject.SetActive(false);
            AmmoButton3.gameObject.SetActive(false);
            AmmoImage4.gameObject.SetActive(false);
            AmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Ammos == 1)
        {
            AmmoImage1.gameObject.SetActive(true);
            AmmoButton1.gameObject.SetActive(true);
            AmmoImage2.gameObject.SetActive(false);
            AmmoButton2.gameObject.SetActive(false);
            AmmoImage3.gameObject.SetActive(false);
            AmmoButton3.gameObject.SetActive(false);
            AmmoImage4.gameObject.SetActive(false);
            AmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Ammos == 2)
        {
            AmmoImage1.gameObject.SetActive(true);
            AmmoButton1.gameObject.SetActive(false);
            AmmoImage2.gameObject.SetActive(true);
            AmmoButton2.gameObject.SetActive(true);
            AmmoImage3.gameObject.SetActive(false);
            AmmoButton3.gameObject.SetActive(false);
            AmmoImage4.gameObject.SetActive(false);
            AmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Ammos == 3)
        {
            AmmoImage1.gameObject.SetActive(true);
            AmmoButton1.gameObject.SetActive(false);
            AmmoImage2.gameObject.SetActive(true);
            AmmoButton2.gameObject.SetActive(false);
            AmmoImage3.gameObject.SetActive(true);
            AmmoButton3.gameObject.SetActive(true);
            AmmoImage4.gameObject.SetActive(false);
            AmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Ammos == 4)
        {
            AmmoImage1.gameObject.SetActive(true);
            AmmoButton1.gameObject.SetActive(false);
            AmmoImage2.gameObject.SetActive(true);
            AmmoButton2.gameObject.SetActive(false);
            AmmoImage3.gameObject.SetActive(true);
            AmmoButton3.gameObject.SetActive(false);
            AmmoImage4.gameObject.SetActive(true);
            AmmoButton4.gameObject.SetActive(true);
        }

    }
  
    public void HealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100)
        {
            SaveScript.PlayerHealth += 10;
            SaveScript.HealthChanged = true;
            SaveScript.Apples -= 1;
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
            if (SaveScript.PlayerHealth > 100)
            {
                SaveScript.PlayerHealth = 100;
            }
        }

       
    }


    public void BatteryUpdate()
    {
       
            SaveScript.BatteryRefill = true;
            SaveScript.Batteries -= 1;
        MyPlayer.clip = BatteryChange;
        MyPlayer.Play();

    }
    public void AssignKnife() //Knife
    {
        PlayerArms.gameObject.SetActive(true);
        Knife.gameObject.SetActive(true);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
    }
    public void AssignBat() //Bat
    {
        PlayerArms.gameObject.SetActive(true);
        Bat.gameObject.SetActive(true);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();

    }
    public void AssignCrossbow() //Crossbow
    {
        PlayerArms.gameObject.SetActive(true);
        Crossbow.gameObject.SetActive(true);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
    }
    public void AssignGun() //Gun
    {
        PlayerArms.gameObject.SetActive(true);
        Gun.gameObject.SetActive(true);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
    }
    public void AssignAxe() //Axe
    {
        PlayerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(true);
        MyPlayer.clip = WeaponChange;
        MyPlayer.Play();
    }
    public void WeaponsOff()
    {
        Axe.gameObject.SetActive(false);
        Bat.gameObject.SetActive(false);
        Knife.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
    }


}
