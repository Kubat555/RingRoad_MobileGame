using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTheme : MonoBehaviour
{
    [SerializeField] Image menu;
    [SerializeField] Image background;
    [SerializeField] Image player;
    [SerializeField] Image circle;
    [SerializeField] Theme[] themes;


    private void Awake() {
        useTheme(themes[0]);
    }

    public void useTheme(Theme t){
        menu.color = t.menuColor;
        background.color = t.backColor;
        player.color = t.playerColor;
        circle.color = t.circleColor;
    }
}
