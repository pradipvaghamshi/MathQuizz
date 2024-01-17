using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScripts : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingPanel, PlayPanel, ExitPanel,SettingPanel,SettingBack;
    [SerializeField]
    Image slider;
    [SerializeField]
    float speed;
    float MaxValue;
    bool Flag;
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite MusicOnImg, MusicOffImg, SoundOnImg, SoundOffImg;
    [SerializeField]
    AudioClip MusicClip, SoundClip;
    void Start()
    {
        MaxValue = slider.fillAmount;
        MusicSet();
        SoundSet();
    }

    public void ExitGame()
    {
        SoundClickPlay();
        ExitPanel.SetActive(true);
        PlayPanel.SetActive(false);
    }
    public void EXitExitPanel()
    {
        SoundClickPlay();
        PlayPanel.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void PlayBTNClick()
    {
        SoundClickPlay();
        PlayPanel.SetActive(false);
        LoadingPanel.SetActive(true);
        Flag = true;
    }
    private void Update()                   //loading time line
    {
        if (Flag)
        {
            if (slider.fillAmount < 1)
            {
                slider.fillAmount += speed * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
    public void SoundImgManager()       //sound manager
    {
        SoundClickPlay();
        if (CommanScript.Instance.Sound)
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
            CommanScript.Instance.Sound = false;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
            CommanScript.Instance.Sound = true;
        }
    }
    public void MusicImgManager()       //music manager
    {
        SoundClickPlay();
        if (CommanScript.Instance.Music)
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            MusicBtn.GetComponent<Image>().sprite = MusicOffImg;
            CommanScript.Instance.Music = false;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            MusicBtn.GetComponent<Image>().sprite = MusicOnImg;
            CommanScript.Instance.Music = true;
        }
    }
    public void SoundClickPlay()        //sound play click
    {
        CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }
    public void SettingON()
    {
        SoundClickPlay();
        SettingPanel.SetActive(true);

    }
    public void SettingOFF()
    {
        SoundClickPlay();
        SettingBack.SetActive(true);
        SettingPanel.SetActive(false);
    }
    public void SoundSet()     //sound set
    { 
        if (CommanScript.Instance.Sound)
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;

            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
        }
    }
    public void MusicSet()     //music set
    { 
        if (CommanScript.Instance.Music)
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            MusicBtn.GetComponent<Image>().sprite = MusicOnImg;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            MusicBtn.GetComponent<Image>().sprite = MusicOffImg;
        }
    }
}

