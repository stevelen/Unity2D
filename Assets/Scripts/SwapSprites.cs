using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSprites : MonoBehaviour
{
    public Image FirstBlood;
    public Image FirstUpgrade;
    public Image CreativeKill;
    public Sprite FirstBloodEarned;
    public Sprite FirstUpgradeEarned;
    public Sprite CreativeKillEarned;


    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("KilledFirstEnemy") == 1)
        {
            FirstBlood.sprite = FirstBloodEarned;
        }
        if (PlayerPrefs.GetInt("CreativeKill") == 1)
        {
            CreativeKill.sprite = CreativeKillEarned;
        }
        if (PlayerPrefs.GetInt("GotFirstUpgrade") == 1)
        {
            FirstUpgrade.sprite = FirstUpgradeEarned;
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("KilledFirstEnemy", 0);
        PlayerPrefs.SetInt("CreativeKill", 0);
        PlayerPrefs.SetInt("GotFirstUpgrade", 0);
    }
}
