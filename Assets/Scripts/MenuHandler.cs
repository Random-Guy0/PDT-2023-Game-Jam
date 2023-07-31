using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuHandler : MonoBehaviour
{
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        //if the scene is the main menu, disables the levels selection buttons
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = false;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
            GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
            GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Back").GetComponent<Button>().enabled = false;
            GameObject.Find("Back").GetComponent<Image>().enabled = false;
            GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        //if the scene is anything else, disables all buttons
        else if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex != 5)
        {
            GameObject.Find("PauseTextBackground").GetComponent<Image>().enabled = false;
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Continue").GetComponent<Button>().enabled = false;
            GameObject.Find("Continue").GetComponent<Image>().enabled = false;
            GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Restart").GetComponent<Button>().enabled = false;
            GameObject.Find("Restart").GetComponent<Image>().enabled = false;
            GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
            GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
            GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
            GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
            GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Quit").GetComponent<Button>().enabled = false;
            GameObject.Find("Quit").GetComponent<Image>().enabled = false;
            GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
            GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
            GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
            GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
            GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Back").GetComponent<Button>().enabled = false;
            GameObject.Find("Back").GetComponent<Image>().enabled = false;
            GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //checks if the scene is not the main menu, then checks if p is pressed. If the game is not already paused
        //the buttons are enabled, otherwise they are disabled/
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex != 5)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (paused == false)
                {
                    GameObject.Find("PauseTextBackground").GetComponent<Image>().enabled = true;
                    GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    GameObject.Find("Continue").GetComponent<Button>().enabled = true;
                    GameObject.Find("Continue").GetComponent<Image>().enabled = true;
                    GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    GameObject.Find("Restart").GetComponent<Button>().enabled = true;
                    GameObject.Find("Restart").GetComponent<Image>().enabled = true;
                    GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    GameObject.Find("MainMenu").GetComponent<Button>().enabled = true;
                    GameObject.Find("MainMenu").GetComponent<Image>().enabled = true;
                    GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    GameObject.Find("LevelSelect").GetComponent<Button>().enabled = true;
                    GameObject.Find("LevelSelect").GetComponent<Image>().enabled = true;
                    GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    GameObject.Find("Quit").GetComponent<Button>().enabled = true;
                    GameObject.Find("Quit").GetComponent<Image>().enabled = true;
                    GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    paused = true;
                }
                else if (paused == true)
                {
                    GameObject.Find("PauseTextBackground").GetComponent<Image>().enabled = false;
                    GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Continue").GetComponent<Button>().enabled = false;
                    GameObject.Find("Continue").GetComponent<Image>().enabled = false;
                    GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Restart").GetComponent<Button>().enabled = false;
                    GameObject.Find("Restart").GetComponent<Image>().enabled = false;
                    GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
                    GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
                    GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
                    GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
                    GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Quit").GetComponent<Button>().enabled = false;
                    GameObject.Find("Quit").GetComponent<Image>().enabled = false;
                    GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
                    GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
                    GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
                    GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
                    GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
                    GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
                    GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
                    GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
                    GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("Back").GetComponent<Button>().enabled = false;
                    GameObject.Find("Back").GetComponent<Image>().enabled = false;
                    GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    paused = false;
                }
            }
        }
    }


    //public getter that checks if the game is paused. used by the character controllers and character switcher
    //to check if they aer allowed to do certain actions
    public bool isPaused()
    {
        if (paused == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //if the start button is presssed, the game switches over to the next available scene in the build index
    public void startGame()
    {
        mainLoadingButtonsDisabled();
        GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
        GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        StartCoroutine(WaitThenLoadScene(3, 1));
    }



    //if a continue button is pressed, the buttons are disabled
    public void continueGame()
    {
        GameObject.Find("PauseTextBackground").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Continue").GetComponent<Button>().enabled = false;
        GameObject.Find("Continue").GetComponent<Image>().enabled = false;
        GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Restart").GetComponent<Button>().enabled = false;
        GameObject.Find("Restart").GetComponent<Image>().enabled = false;
        GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
        GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        paused = false;
    }

    //loads the main menu
    public void LoadMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 5)
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
            GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
            GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Quit").GetComponent<Button>().enabled = false;
            GameObject.Find("Quit").GetComponent<Image>().enabled = false;
            GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        StartCoroutine(WaitThenLoadScene(3, 0));
    }

    //loads the tutorial
    public void LoadTutorial()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        StartCoroutine(WaitThenLoadScene(3, 1));
    }

    //loads level 1
    public void LoadLevelOne()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        StartCoroutine(WaitThenLoadScene(3, 2));
    }

    //loads level 2
    public void LoadLevelTwo()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        StartCoroutine(WaitThenLoadScene(3, 3));
    }

    //loads level 3
    public void LoadLevelThree()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        StartCoroutine(WaitThenLoadScene(3, 4));
    }

    //restarts the current level
    public void RestartLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainLoadingButtonsDisabled();
            GameObject.Find("TextBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("TextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            pauseLoadingButtonsDisabled();
            GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loading...";
        }
        StartCoroutine(WaitThenLoadScene(3, SceneManager.GetActiveScene().buildIndex));
    }

    //quits the game
    public void quit()
    {
        Application.Quit();
    }

    //if it is the main menu and the level select button is pressed, first set of main menu buttons are disabled, and level buttons enabled
    public void mainMenuLevelSelector()
    {
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").GetComponent<Image>().enabled = false;
        GameObject.Find("Start").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = true;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = true;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Back").GetComponent<Button>().enabled = true;
        GameObject.Find("Back").GetComponent<Image>().enabled = true;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
    }

    //if it is the main menu and the back button is pressed, first set of main menu buttons are enabled, and level buttons disabled
    public void mainMenuBack()
    {
        GameObject.Find("Start").GetComponent<Button>().enabled = true;
        GameObject.Find("Start").GetComponent<Image>().enabled = true;
        GameObject.Find("Start").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = true;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = true;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Quit").GetComponent<Button>().enabled = true;
        GameObject.Find("Quit").GetComponent<Image>().enabled = true;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    //if it is the pause menu and the level select button is pressed, first set of main menu buttons are disabled, and level buttons enabled
    public void pauseMenuLevelSelector()
    {
        GameObject.Find("Continue").GetComponent<Button>().enabled = false;
        GameObject.Find("Continue").GetComponent<Image>().enabled = false;
        GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Restart").GetComponent<Button>().enabled = false;
        GameObject.Find("Restart").GetComponent<Image>().enabled = false;
        GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
        GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = true;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = true;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = true;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Back").GetComponent<Button>().enabled = true;
        GameObject.Find("Back").GetComponent<Image>().enabled = true;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
    }

    //if it is the pause menu and the level select button is pressed, first set of main menu buttons are disabled, and level buttons enabled
    public void pauseMenuBack()
    {
        GameObject.Find("PauseTextBackground").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseTextBackground").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Continue").GetComponent<Button>().enabled = true;
        GameObject.Find("Continue").GetComponent<Image>().enabled = true;
        GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Restart").GetComponent<Button>().enabled = true;
        GameObject.Find("Restart").GetComponent<Image>().enabled = true;
        GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("MainMenu").GetComponent<Button>().enabled = true;
        GameObject.Find("MainMenu").GetComponent<Image>().enabled = true;
        GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = true;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = true;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Quit").GetComponent<Button>().enabled = true;
        GameObject.Find("Quit").GetComponent<Image>().enabled = true;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void mainLoadingButtonsDisabled()
    {
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").GetComponent<Image>().enabled = false;
        GameObject.Find("Start").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }
    public void pauseLoadingButtonsDisabled()
    {
        GameObject.Find("Continue").GetComponent<Button>().enabled = false;
        GameObject.Find("Continue").GetComponent<Image>().enabled = false;
        GameObject.Find("Continue").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Restart").GetComponent<Button>().enabled = false;
        GameObject.Find("Restart").GetComponent<Image>().enabled = false;
        GameObject.Find("Restart").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Button>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Image>().enabled = false;
        GameObject.Find("MainMenu").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Button>().enabled = false;
        GameObject.Find("LevelSelect").GetComponent<Image>().enabled = false;
        GameObject.Find("LevelSelect").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false; GameObject.Find("Tutorial").GetComponent<Button>().enabled = false;
        GameObject.Find("Tutorial").GetComponent<Image>().enabled = false;
        GameObject.Find("Tutorial").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 1").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 2").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Button>().enabled = false;
        GameObject.Find("Level 3").GetComponent<Image>().enabled = false;
        GameObject.Find("Level 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("Back").GetComponent<Button>().enabled = false;
        GameObject.Find("Back").GetComponent<Image>().enabled = false;
        GameObject.Find("Back").transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    IEnumerator WaitThenLoadScene(float waitTime, int level)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(level);
    }
}

