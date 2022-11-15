using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
struct ButtonBuy{
    public Button btn;
    public TextMeshProUGUI textMesh;
}

public class ChangeTheme : MonoBehaviour
{
    static public ChangeTheme instance;
    [SerializeField] Image menu;
    [SerializeField] Image background;
    [SerializeField] Image player;
    [SerializeField] Image circle;
    [SerializeField] Image[] bgElements;
    [SerializeField] List<Theme> themes;

    [Header("CoinsText")]
    [SerializeField] TextMeshProUGUI coinsText;

     [Header("ButtonColors")]
    [SerializeField] private Color colorOrange;
    [SerializeField] private Color colorGreen;

    [Header("Buttons")]
    [SerializeField] ButtonBuy[] buttons;
    [SerializeField] GameObject notEnoughMoneyText;
    int prevIndex;


    Theme currentTheme;
    const string CURRENT_THEME = "CurrentTheme";


    private void Awake() {
        if(instance == null){
            instance = this;
        }
        
    }
    private void Start() {
        prevIndex = PlayerPrefs.GetInt(CURRENT_THEME, 0);
        if(themes[prevIndex].isOpen){
            currentTheme = themes[prevIndex];
        }else{
            prevIndex = 0;
            currentTheme = themes[prevIndex];
        }
        
        UseTheme(currentTheme);
        ChangeButtonToSelected(prevIndex);

        for(int i = 0; i < buttons.Length; i++){
            if(themes[i].isOpen){
                ChangeButtonToSelect(i);
            }
        }
    }

    public void UseTheme(Theme t){
        menu.color = t.menuColor;
        background.color = t.backColor;
        player.color = t.playerColor;
        circle.color = t.circleColor;
        for(int i = 0; i < bgElements.Length; i++){
            bgElements[i].color = t.BgObjects[i];
        }
        currentTheme = t;
    }

    public void ChangeCurrentTheme(int themeIndex){
        if(prevIndex != themeIndex){
            if(themes[themeIndex].isOpen){
                PlayerPrefs.SetInt(CURRENT_THEME, themeIndex);
                PlayerPrefs.Save();
                UseTheme(themes[themeIndex]);
                ChangeButtonToSelected(themeIndex);
                ChangeButtonToSelect(prevIndex);
                prevIndex = themeIndex;
            }
            else{
                if(PlayerPrefs.GetFloat("MaxScore") >= themes[themeIndex].Price){
                    PlayerPrefs.SetFloat("MaxScore", PlayerPrefs.GetFloat("MaxScore") - themes[themeIndex].Price);
                    themes[themeIndex].isOpen = true;
                    ChangeButtonToSelect(themeIndex);
                    UpdateCoinsText();
                }
                else{
                    Debug.Log("Не достаточно бабла!");
                    notEnoughMoneyText.GetComponent<Animator>().SetTrigger("Warning");
                }
            }
        }
        
    }

    public void ChangeButtonToSelected(int index){
        buttons[index].btn.GetComponent<Image>().color = colorGreen;
        buttons[index].textMesh.text = "Selected";
    }

    public void ChangeButtonToSelect(int index){
        buttons[index].btn.GetComponent<Image>().color = colorOrange;
        buttons[index].textMesh.text = "Select";
    }


    public void UpdateCoinsText(){
        coinsText.text = PlayerPrefs.GetFloat("MaxScore").ToString();
        ChangeButtonToSelected(prevIndex);
    }


    public void OpenPremiumTheme(){
        themes[4].isOpen = true;
        ChangeButtonToSelect(4);
    }
}



