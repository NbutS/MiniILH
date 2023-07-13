using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{

    public static Menu instance;
    
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject level_1;
    [SerializeField] private GameObject level_2;
    [SerializeField] private GameObject level_3;
    [SerializeField] private GameObject level_4;
    [SerializeField] private GameObject level_5;
    [SerializeField] private GameObject level_6;
    [SerializeField] private GameObject level_7;
    [SerializeField] private GameObject level_8;
    [SerializeField] private GameObject level_9;
    [SerializeField] private GameObject level_10;
    [SerializeField] private GameObject level_11;
    [SerializeField] private GameObject level_12;
    [SerializeField] private GameObject level_13;
    [SerializeField] private GameObject level_14;
    [SerializeField] private GameObject level_15;
    public bool onMusic = true;


   
    private void Start()
    {
        Debug.Log("Start Menu");
        if (PlayerPrefs.GetInt("Music On") == 1)
            FindObjectOfType<AudioManager>().Play("MusicBackground");
        level_1.GetComponent<Image>().color = Color.yellow;
        PlayerPrefs.SetInt("Level", 1);
        levelText.text = "Level 1";
    }


    public void Level1()
    {
        level_1.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 1";
        PlayerPrefs.SetInt("Level", 1);
        FindObjectOfType<AudioManager>().Play("ClickButton");
        
        
    }
    public void Level2()
    {
        level_2.GetComponent<Image>().color = Color.yellow;
        level_1.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 2";
        PlayerPrefs.SetInt("Level", 2);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level3()
    {
        level_3.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 3";
        PlayerPrefs.SetInt("Level", 3);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level4()
    {
        level_4.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 4";
        PlayerPrefs.SetInt("Level", 4);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }

    public void Level5()
    {
        level_5.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 5";
        PlayerPrefs.SetInt("Level", 5);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level6()
    {
        level_6.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 6";
        PlayerPrefs.SetInt("Level", 6);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level7()
    {
        level_7.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 7";
        PlayerPrefs.SetInt("Level", 7);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level8()
    {
        level_8.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 8";
        PlayerPrefs.SetInt("Level", 8);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level9()
    {
        level_9.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 9";
        PlayerPrefs.SetInt("Level", 9);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level10()
    {
        level_10.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 10";
        PlayerPrefs.SetInt("Level", 10);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level11()
    {
        level_11.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 11";
        PlayerPrefs.SetInt("Level", 11);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level12()
    {
        level_12.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 12";
        PlayerPrefs.SetInt("Level", 12);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level13()
    {
        level_13.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 13";
        PlayerPrefs.SetInt("Level", 13);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level14()
    {
        level_14.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        level_15.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 14";
        PlayerPrefs.SetInt("Level", 14);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void Level15()
    {
        level_15.GetComponent<Image>().color = Color.yellow;
        level_2.GetComponent<Image>().color = Color.white;
        level_3.GetComponent<Image>().color = Color.white;
        level_1.GetComponent<Image>().color = Color.white;
        level_4.GetComponent<Image>().color = Color.white;
        level_6.GetComponent<Image>().color = Color.white;
        level_5.GetComponent<Image>().color = Color.white;
        level_7.GetComponent<Image>().color = Color.white;
        level_9.GetComponent<Image>().color = Color.white;
        level_8.GetComponent<Image>().color = Color.white;
        level_11.GetComponent<Image>().color = Color.white;
        level_12.GetComponent<Image>().color = Color.white;
        level_13.GetComponent<Image>().color = Color.white;
        level_14.GetComponent<Image>().color = Color.white;
        level_10.GetComponent<Image>().color = Color.white;
        levelText.text = "Level 15";
        PlayerPrefs.SetInt("Level", 15);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
}
