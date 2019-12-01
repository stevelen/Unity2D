using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achiPopup : MonoBehaviour
{

    private float targetTime = 5f;
    private bool timer = false;
    public Image achiimg;
    public Sprite FirstBloodEarned;
    public Sprite FirstUpgradeEarned;
    public Sprite CreativeKillEarned;
    // Start is called before the first frame update
    void Start()
    {
        achiimg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            targetTime -= Time.deltaTime;
        }
        if (targetTime <= 0.0f)
        {
            achiimg.enabled = false;
            timer = false;
            targetTime = 5f;
            
        }
    }

    public void popup()
    {
        timer = true;
        achiimg.enabled = true;
    }

    public void setSprite1()
    {
        achiimg.sprite = FirstBloodEarned;
    }
    public void setSprite2()
    {
        achiimg.sprite = FirstUpgradeEarned;
    }
    public void setSprite3()
    {
        achiimg.sprite = CreativeKillEarned;
    }
}
