using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int highScore;
    [HideInInspector] public int kills;
    [HideInInspector] public float health;
    [HideInInspector] public float maxHealth;
    [HideInInspector] public float healthSlider;
    [HideInInspector] public float ammoClip;
    [HideInInspector] public float ammoMax;
    public float damageMultiplyer = 1.0f;
    public Text highScoreText;
    public Text killsText;
    public Text healthText;
    public Text ammoMaxCounter;
    public Text ammoClipCounter;

    // Start is called before the first frame update
   void Start()
    {
       highScore = PlayerPrefs.GetInt("KILLS");
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().maxHealth;
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

        ammoClip = GameObject.FindGameObjectWithTag("Gun").GetComponent<AmmoBehaviour>().ammoClip;
        ammoMax = GameObject.FindGameObjectWithTag("Gun").GetComponent<AmmoBehaviour>().ammoMax;

        ammoMaxCounter.text = "" + ammoMax; 
        ammoClipCounter.text = "" + ammoClip;

        OnGUI();
        HealthColour();

    }

    void OnGUI()
    {
        if (ammoClip == 0)
        {
            ammoClipCounter.color = Color.red;
        }

        else
        {
            ammoClipCounter.color = Color.black;
        }

    }
        
    void HealthColour()
    {

        if (health <= maxHealth / 5)
        {
            healthText.color = Color.red;
        }

        else if (health <= maxHealth/2)
        {
            healthText.color = Color.yellow;
        }

        else
        {
            healthText.color = Color.green;
        }

    }


}
