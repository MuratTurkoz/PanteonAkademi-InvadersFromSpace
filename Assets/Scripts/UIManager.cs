using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Image[] lifeSprites;
    [SerializeField] Sprite[] healthBars;
    [SerializeField] Image healthBar;
    Color32 active = new Color(1,1,1,1);
    Color32 inActive = new Color(1, 1, 1, 0.25f);
    int score;
    int highscore;
    int coin;
    int wave;
    private static UIManager instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    public static void UpdateLives(int l)
    {
        foreach (Image item in instance.lifeSprites)
        {
            item.color = instance.inActive;
        }
        for (int i = 0; i < l; i++)
        {
            instance.lifeSprites[i].color = instance.active;
        }
    }
    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text=instance.score.ToString("000,000");
    }
    public static void UpdateHealthBar(int h)
    {
        instance.healthBar.sprite = instance.healthBars[h];
    }
    public static void UpdateHighScore()
    {
        //TODO
    }
    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }
    public static void UpdateCoins()
    {
        //TODO
        instance.coinText.text = Invertory.currentCoins.ToString();
    }
}
