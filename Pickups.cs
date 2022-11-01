using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;
    [SerializeField] GameObject PlayerArms;
    private AudioSource MyPlayer;

    private float RayDistance;
    private bool CanSeePickup = false;

    private bool CanSeeDoor = false;
    [SerializeField] GameObject DoorMessage;
    [SerializeField] Text DoorText;

    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        DoorMessage.gameObject.SetActive(false);
        PlayerArms.gameObject.SetActive(false);
        RayDistance = Distance;
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                CanSeePickup = true;
                if (SaveScript.Apples < 6)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Apples += 1;
                        MyPlayer.Play();
                    }
                }
            }

            //Battery pickup
            else if (hit.transform.tag == "Battery")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteries < 4)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Batteries += 1;
                        MyPlayer.Play();
                    }
                }
            }
            //Knife pickup
            else if (hit.transform.tag == "Knife")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Knife == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Knife = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Axe pickup
            else if (hit.transform.tag == "Axe")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Axe == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Axe = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Bat pickup
            else if (hit.transform.tag == "Bat")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Bat == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Bat = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Gun pickup
            else if (hit.transform.tag == "Gun")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Gun == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Gun = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Crossbow pickup
            else if (hit.transform.tag == "Crossbow")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Crossbow == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Crossbow = true;
                        MyPlayer.Play();
                    }
                }
            }

            //Key pickups

            //Housekey
            else if (hit.transform.tag == "HouseKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Housekey == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Housekey = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Roomkey
            else if (hit.transform.tag == "RoomKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Roomkey == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Roomkey = true;
                        MyPlayer.Play();
                    }
                }
            }
            //Cabinkey
            else if (hit.transform.tag == "CabinKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Cabinkey == false)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Cabinkey = true;
                        MyPlayer.Play();
                    }
                }
            }

            //Ammo pickups
            else if (hit.transform.tag == "Ammo")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Ammos < 4)
                    {

                        Destroy(hit.transform.gameObject);
                        SaveScript.Ammos += 1;
                        MyPlayer.Play();
                    }
                }
            }

            //Arrow pickups
            else if (hit.transform.tag == "Arrow")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Arrows == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Arrows = true;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Door")
            {
                CanSeeDoor = true;
                if (hit.transform.gameObject.GetComponent<DoorScript>().Locked == false)
                {


                    if (hit.transform.gameObject.GetComponent<DoorScript>().IsOpen == false)

                    {
                        DoorText.text = "Press E to Open";
                    }
                    if (hit.transform.gameObject.GetComponent<DoorScript>().IsOpen == true)

                    {
                        DoorText.text = "Press E to Close";
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessage("DoorOpen");
                    }
                }

                else if (hit.transform.gameObject.GetComponent<DoorScript>().Locked == true)
                {
                    DoorText.text = "You need the " + hit.transform.gameObject.GetComponent<DoorScript>().DoorType + " key";
                }
            }


            else
            {
                CanSeePickup = false;
                CanSeeDoor = false;
            }
        }

        if (CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }
        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }

        if (CanSeeDoor == true)
        {
            DoorMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }
        if (CanSeeDoor == false)
        {
            DoorMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }
    }
}
