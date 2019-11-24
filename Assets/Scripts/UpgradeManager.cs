using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text speedText;
    public Text jumpText;
    public int speed = 1;
    public int jump = 1;

    public void addSpeed(int x)
    {
        speed += x;
        speedText.text = "Speed: " + speed;
    }

    public void addJump(int x)
    {
        jump += x;
        jumpText.text = "Jump: " + jump;
    }

}
