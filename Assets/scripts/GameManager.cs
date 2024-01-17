using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics.Tracing;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject SelectionPanel, LavelPanel, GameOverPanel, GameOverRst, SettingPanel, SettingBack;
    [SerializeField]
    TextMeshProUGUI OPText, RightText, LeftText;
    [SerializeField]
    GameObject LavelBtn, SelectionBtn;
    float Value1, Value2,Ans;
    [SerializeField]
    List<int> AnsValue;
    [SerializeField]
    TextMeshProUGUI[] ForthBtn;
    int variable;
    [SerializeField]
    bool flag;
    [SerializeField]
    Image slider;
    [SerializeField]
    float Speed;
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite MusicOnImg, MusicOffImg, SoundOnImg, SoundOffImg;
    [SerializeField]
    AudioClip MusicClip, SoundClip;
    void Start()
    {
        MusicSet();
        SoundSet();
    }
    public void StartLavel()
    {
        SoundClickPlay();
        SelectionPanel.SetActive(false);
        LavelPanel.SetActive(true);
    }
    public void selection(int value)
    {
        //Debug.Log("Panel ->"+value);
        SoundClickPlay();
        variable = value;
        flag = true;
        Gameswitch();
    }
    public void LavelBack()
    {
        SoundClickPlay();
        flag = false;
        slider.fillAmount = 1;
        SelectionPanel.SetActive(true);
        LavelBtn.SetActive(false);
    }

    public void GameRst()
    {
        SoundClickPlay();
        GameOverRst.SetActive(false);
        slider.fillAmount = 1;
        LavelPanel.SetActive(true);
    }

    public void GameOver()
    {
        SoundClickPlay();
        SelectionPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void BackBTN()
    {
        SoundClickPlay();
        SceneManager.LoadScene("HomeScene");
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

    void Update()
    {
        if (flag)       // game over time line
        {
            if (slider.fillAmount > 0)
            {
                slider.fillAmount -= Speed * Time.deltaTime;
            }
            else
            {
                GameOverPanel.SetActive(true);
                LavelPanel.SetActive(false);
            }
        }
    }
    public void Gameswitch()
    {
        SoundClickPlay();
        switch (variable)       // quation random code
        {
            case 1:
                OPText.text = "+";
                Value1 = Random.Range(0, 20);
                Value2 = Random.Range(0, 20);
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 + Value2;
                Debug.Log("plus is active" + Ans);
                ;
                break;
            case 2:
                OPText.text = "-";
                Value1 = Random.Range(0, 20);
                Value2 = Random.Range(0, 20);
                if (Value1 < Value2)
                {
                    float Temp = Value1;
                    Value1 = Value2;
                    Value2 = Temp;
                }
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 - Value2;
                Debug.Log("minus is active" + Ans);
                
                break;
            case 3:
                OPText.text = "X";
                Value1 = Random.Range(1, 10);
                Value2 = Random.Range(1, 10);
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 * Value2;
                Debug.Log("multi is active" + Ans);
                
                break;
            case 4:
                OPText.text = "/";
                Value2 = Random.Range(4,15);
                Value1 = Value2*Random.Range(5,16 );
                RightText.text = Value1.ToString();
                LeftText.text = Value2.ToString();
                Ans = Value1 / Value2;
                Ans=(float)System.Math.Round(Ans,2);
                Debug.Log("divide is active" + Ans);
                
                break;
        }
        flag = true;
        ValueActive();
    }
    public void ValueActive()       //value ganrate
    {
        SoundClickPlay();
        AnsValue.Clear();
        for (int i = 0; i < 3; i++)
        {
            int GenrateValue;
            do
            {
                GenrateValue = Random.Range(1, 82);
            }while (AnsValue.Contains(GenrateValue)||Ans == GenrateValue);
            
            AnsValue.Add(GenrateValue);
        }
        RandomVal();
    }
    void RandomVal()        //random value 
    {
        SoundClickPlay();
        int Value;
        int Counter = 0;
        Value = Random.Range(0, ForthBtn.Length);
        for (int i = 0; i < ForthBtn.Length; i++)
        {
           
            if (Value == i)
            {
                ForthBtn[i].text = Ans.ToString();
            }
            else
            {
                ForthBtn[i].text = AnsValue[Counter].ToString();
                Counter++;
            }
        }
    }
    public void AnsCheak(TextMeshProUGUI CheakAns)      //ans check
    {
        SoundClickPlay();
        if (CheakAns.text == Ans.ToString())
        {
            Gameswitch();
            slider.fillAmount = 1;
            Debug.Log("Ans is right");
        }
        else
        {
            Debug.Log("Ans is Wrong");
            LavelPanel.SetActive(false);
            GameOverPanel.SetActive(true);
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

