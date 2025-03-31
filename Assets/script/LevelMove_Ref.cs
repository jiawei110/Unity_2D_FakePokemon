using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public Unit player;
    public ItemUnit item;

    public Animator transition;
    bool triggered = false;



    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other)
    {

        SaveSystem.SavePlayer(player, item);

        if (!triggered)
        {
            print("Trigger Entered");


            EnemyData enemy = new EnemyData();
            // Could use other.GetComponent<Player>() to see if the game object has a Player component
            // Tags work too. Maybe some players have different script components?
            if (other.tag == "Enemy")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);

                FindObjectOfType<AudioManager>().audio_play("Battle Normal");
                Debug.Log("whitegirl trigger");
                enemy.setComponent(1);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");




            }
            if (other.tag == "purpleguy")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                FindObjectOfType<AudioManager>().audio_play("Battle Normal");
                Debug.Log("purpleguy trigger");
                enemy.setComponent(2);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");




            }
            if (other.tag == "berserker")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                FindObjectOfType<AudioManager>().audio_play("Battle BBBoss");
                Debug.Log("berserker trigger");
                enemy.setComponent(3);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");



            }
            if (other.tag == "oldman")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                FindObjectOfType<AudioManager>().audio_play("Battle Gym");
                Debug.Log("oldman trigger");
                enemy.setComponent(4);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");



            }
            if (other.tag == "yamada")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                FindObjectOfType<AudioManager>().audio_play("Battle Boss");
                Debug.Log("yamada trigger");
                enemy.setComponent(5);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");



            }
            if (other.tag == "activegirl")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                FindObjectOfType<AudioManager>().audio_play("Battle Boss");
                Debug.Log("activegirl trigger");
                enemy.setComponent(6);
                SaveSystem.SaveEnemy(enemy);
                LoadLevel(3);
                // Player entered, so move level
                print("Switching Scene to 2");




            }





            if (other.tag == "school")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(8);
                // Player entered, so move level
                print("Switching Scene to 7");



            }
            if (other.tag == "shop")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(4);
                // Player entered, so move level
                print("Switching Scene to 3");



            }
            if (other.tag == "arena")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(10);
                // Player entered, so move level
                print("Switching Scene to 9");



            }
            if (other.tag == "gamecenter")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(6);
                // Player entered, so move level
                print("Switching Scene to 5");



            }
            if (other.tag == "shop_weapon")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(5);
                // Player entered, so move level
                print("Switching Scene to 4");



            }
            if (other.tag == "healStation")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(7);
                // Player entered, so move level
                print("Switching Scene to 6");



            }
            if (other.tag == "home")
            {
                triggered = true;
                FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                LoadLevel(9);
                // Player entered, so move level
                print("Switching Scene to 8");



            }


            if (other.tag == "Respawn")
            {
                triggered = true;
                //FindObjectOfType<AudioManager>().StopAudio();
                transition.SetBool("start", true);
                SaveSystem.SavePlayer(player, item);
                LoadLevel(1);
                // Player entered, so move level
                print("Switching Scene to 0");




            }
        }
    }

    public void LoadLevel(int sceneBuildIndex) {
        //FindObjectOfType<AudioManager>().StopAudio();
        //SaveSystem.SavePlayer(player, item);
        transition.SetBool("start", true);
        StartCoroutine(LoadLevel_delay_loader_exist(sceneBuildIndex));
    }

    IEnumerator LoadLevel_delay_loader_exist(int scene)
    {


        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(scene, LoadSceneMode.Single);


    }
    public void exit() 
    {
        Application.Quit();
    }
}