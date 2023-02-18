using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EXPManager : MonoBehaviour
{
    public TextMeshProUGUI currentXPtext;
    public TextMeshProUGUI targetXPtext;
    public TextMeshProUGUI lvlText;

    public int currentXP, targetEXP, lvl;

    public static EXPManager instance;

    private void Awake()
    {
        currentXP = 0;
        targetEXP = 5;
        lvl = 1;
        if (instance == null) { instance = FindObjectOfType<EXPManager>(); }
    }

    private void Start()
    {
        targetXPtext.text = "/" + targetEXP.ToString();
        currentXPtext.text = currentXP.ToString();
        lvlText.text = lvl.ToString();
    }

    public static void AddXP(int xp)
    {
        instance.currentXP += xp;
        while (instance.currentXP >= instance.targetEXP)
        {
            instance.currentXP = instance.currentXP - instance.targetEXP;
            instance.lvl++;
            instance.targetEXP +=  instance.targetEXP * 25/100;

            instance.lvlText.text = instance.lvl.ToString();
            instance.targetXPtext.text = "/" + instance.targetEXP.ToString();
        }

        instance.currentXPtext.text = instance.currentXP.ToString();
    }
}
