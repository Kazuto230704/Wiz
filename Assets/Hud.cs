using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hud : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text Score_Text;
    public TMP_Text MP_Text;
    public TMP_Text HP_Text;
    public static int score = 0;
    public static int mp = 100;
    public static int hp = 100;
    public float timer = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score: " + score;
        MP_Text.text = "MP: " + mp;
        HP_Text.text = "HP: "+ hp;

        timer += Time.deltaTime;

        if (Wizard.movement == Vector3.zero){
            if (timer > 5){
                mp += 10;
            }
        }
    }
}
