using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int highScore;
    [HideInInspector] public int kills;
    [HideInInspector] public float health;
    public float damageMultiplyer = 1.0f;
    public Text highScoreText;
    public Text killsText;
    public Text healthText;
    public Text ammoCounter;

    // Start is called before the first frame update
   void Start()
    {
       highScore = PlayerPrefs.GetInt("KILLS");
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().health;
        killsText.text = "Kills:" + kills;
        healthText.text = "Health: " + health;

        if(highScore < kills)
        {
            PlayerPrefs.SetInt("KILLS", kills);
            PlayerPrefs.Save();
            highScore = kills;
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
