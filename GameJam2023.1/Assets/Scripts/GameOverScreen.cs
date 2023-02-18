using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen instance;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject[] MiscOnRemove;
    [SerializeField] private GameObject[] GOMisc;



    // Array of alternative titles
    string[] altTitles = new string[] {
        "You died!",
        "Oblivion",
        "Your Journey Ends Here..or does it?",
        "The End..?",
        "You Have Fallen",
        "Your Last Breath"
    };

    // Array of alternative descriptions
    string[] altDescriptions = new string[] {
        "To respawn, reach level X",
        "Keep trying until you reach level X to respawn",
        "You need to achieve level X to revive",
        "Don't give up! Reach level X to come back to life",
        "Can you make it to level X to continue?",
        "Your fate rests on reaching level X",
        "You must reach level X to earn another chance",
        "It's not over yet. Get to level X to continue",
        "Persevere until you reach level X and revive",
        "Rise from the ashes by reaching level X"
    };

    public int requiredLVL = 1;
    public static bool gameOver = false;

    private void Start()
    {
		if (instance == null) {  instance = FindObjectOfType<GameOverScreen>(); }
    }
    
    public static void GameOver()
    {
        foreach(GameObject g in instance.MiscOnRemove) { g.SetActive(false); }
        instance.GameOverPanel.SetActive(true);
        instance.GameOverPanel.GetComponent<Animator>().SetBool("GameOver", true);
        GameOverScreen.gameOver = true;
        PlayerMovement.CanMove = false;
        if(instance.requiredLVL > EXPManager.instance.lvl)
        {
            //Final game over
            instance.GOMisc[0].GetComponent<TMP_Text>().text = "Game Over!";
            instance.GOMisc[1].GetComponent<TMP_Text>().text = "You didn't reach level " + instance.requiredLVL + ", so the phoenix is unable to respawn.";
            Destroy(instance.GOMisc[2]);
        }else{
            instance.requiredLVL *= 2;
            Debug.Log("Entering game over state");
            instance.GOMisc[0].GetComponent<TMP_Text>().text = instance.altTitles[new System.Random().Next(instance.altTitles.Length)];
            instance.GOMisc[1].GetComponent<TMP_Text>().text = instance.altDescriptions[new System.Random().Next(instance.altDescriptions.Length)].Replace('X', (char)(instance.requiredLVL + '0'));
            SoundManager.PlayMusic("DirgeForADeadBird");
        }
    }

    public void Rebirth()
    {
        SoundManager.PlayMusic("Clear");
		FindObjectOfType<PlayerRebirth>().Rebirth();
        foreach(Transform g2 in instance.MiscOnRemove[4].transform) { Destroy(g2.gameObject); }
        foreach(GameObject g in instance.MiscOnRemove) { g.SetActive(true); }
        instance.GameOverPanel.SetActive(false);
        instance.GameOverPanel.GetComponent<Animator>().SetBool("GameOver", false);
        GameOverScreen.gameOver = false;
    }

    public void Restart() {
        HealthSystem.heal(3f);
        PlayerMovement.CanMove = true;
        GameOverScreen.gameOver = false;
        SceneManager.LoadScene("SampleScene");
    }
}
