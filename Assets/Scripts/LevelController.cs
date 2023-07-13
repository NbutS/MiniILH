using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject turnOnSound;
    [SerializeField] private GameObject turnOffSound;
    [SerializeField] private GameObject turnOnSoundWin;
    [SerializeField] private GameObject turnOffSoundWin;
    
    private void Start()
    {
        gamePlay.SetActive(true);
        pauseScreen.SetActive(false);
        if (PlayerPrefs.GetInt("Music On") == 1 )
        {
            turnOffSound.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
            turnOnSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
            turnOffSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
            turnOnSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        }
        else
        {
            turnOnSound.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
            turnOffSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
            turnOnSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
            turnOffSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        }
       
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePlay.SetActive(false);
        pauseScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        gamePlay.SetActive(true);
        pauseScreen.SetActive(false);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }

    public void TurnOnSound()
    {
        turnOffSound.GetComponent<Image>().color = new Color(166f/255,166f/255,166f/255);
        turnOnSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        turnOffSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOnSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        FindObjectOfType<AudioManager>().Play("MusicBackground");
        FindObjectOfType<AudioManager>().Play("ClickButton");
        PlayerPrefs.SetInt("Music On", 1);

    }
    public void TurnOffSound()
    {
        turnOnSound.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOffSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        turnOnSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOffSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        FindObjectOfType<AudioManager>().PauseMusic("MusicBackground");
        FindObjectOfType<AudioManager>().Play("ClickButton");

        PlayerPrefs.SetInt("Music On", 0);
    }
    public void TurnOnSoundWin()
    {
        turnOffSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOnSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        turnOffSound.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOnSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        FindObjectOfType<AudioManager>().Play("MusicBackground");
        FindObjectOfType<AudioManager>().Play("ClickButton");
        PlayerPrefs.SetInt("Music On", 1);
    }
    public void TurnOffSoundWin()
    {
        turnOnSoundWin.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOffSoundWin.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        turnOnSound.GetComponent<Image>().color = new Color(166f / 255, 166f / 255, 166f / 255);
        turnOffSound.GetComponent<Image>().color = new Color(146f / 255, 217f / 255, 172f / 255);
        FindObjectOfType<AudioManager>().PauseMusic("MusicBackground");
        FindObjectOfType<AudioManager>().Play("ClickButton");
        PlayerPrefs.SetInt("Music On", 0);
    }
    public void BacktoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
