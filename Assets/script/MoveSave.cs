using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSave : MonoBehaviour
{

    //move Save for enter to door by going straight
    public Rigidbody2D rb;
    public Transform player;
    
    Vector3 currentmove;

    string str_currentmove_x;
    string str_currentmove_y;
    string str_currentmove_z;

    // Start is called before the first frame update
    void Start()
    {
        /*change position of Rigidbody2D : failed , cant use this way cause position of Rigidbody2D always follow player transform position
        str_currentmove_x = PlayerPrefs.GetString("CurrentMove_x","-18.07");
        str_currentmove_y = PlayerPrefs.GetString("CurrentMove_y","1.124");
        currentmove.x = Convert.ToSingle(str_currentmove_x);
        currentmove.y = Convert.ToSingle(str_currentmove_y);
        rb.MovePosition(currentmove);
        */
        str_currentmove_x = PlayerPrefs.GetString("CurrentMove_x", "-18.07");
        str_currentmove_y = PlayerPrefs.GetString("CurrentMove_y", "1.124");
        str_currentmove_y = PlayerPrefs.GetString("CurrentMove_y", "0.0");
        //reset PlayerPrefs
        PlayerPrefs.DeleteAll();
        currentmove.x = Convert.ToSingle(str_currentmove_x);
        currentmove.y = Convert.ToSingle(str_currentmove_y);
        currentmove.z = Convert.ToSingle(str_currentmove_z);
        print(currentmove);
        player.position = currentmove;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("Trigger Entered");
        if (other.tag == "school" || other.tag == "shop" || other.tag == "arena" || other.tag == "gamecenter" || other.tag == "shop_weapon" || other.tag == "healStation" || other.tag == "home" ) 
        {
            
            print("transporter trigger");
            /*
            currentmove = rb.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y",str_currentmove_y);
            */
            currentmove = player.position;
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                print("Enter to door from front to back");
                str_currentmove_x = (currentmove.x).ToString();
                str_currentmove_y = (currentmove.y + 0.5).ToString();
                str_currentmove_z = (currentmove.z).ToString();
            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                print("Enter to door from back to front");
                str_currentmove_x = (currentmove.x).ToString();
                str_currentmove_y = (currentmove.y - 0.5).ToString();
                str_currentmove_z = (currentmove.z).ToString();
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                print("Enter to door from right to left");
                str_currentmove_x = (currentmove.x + 0.5).ToString();
                str_currentmove_y = (currentmove.y).ToString();
                str_currentmove_z = (currentmove.z).ToString();
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                print("Enter to door from left to right");
                str_currentmove_x = (currentmove.x - 0.5).ToString();
                str_currentmove_y = (currentmove.y).ToString();
                str_currentmove_z = (currentmove.z).ToString();
            }
            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);

        }
        if (other.tag == "Enemy") 
        {
            print("whiteGirl trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
        if (other.tag == "purpleguy")
        {
            print("purpleguy trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
        if (other.tag == "berserker")
        {
            print("berserker trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
        if (other.tag == "oldman")
        {
            print("oldman trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
        if (other.tag == "yamada")
        {
            print("yamada trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
        if (other.tag == "activegirl")
        {
            print("activegirl trigger, move saved~");

            currentmove = player.position;
            str_currentmove_x = (currentmove.x).ToString();
            str_currentmove_y = (currentmove.y).ToString();
            str_currentmove_z = (currentmove.z).ToString();

            PlayerPrefs.SetString("CurrentMove_x", str_currentmove_x);
            PlayerPrefs.SetString("CurrentMove_y", str_currentmove_y);
            PlayerPrefs.SetString("CurrentMove_z", str_currentmove_z);
        }
    }
}
