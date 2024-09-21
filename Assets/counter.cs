using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counter : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> text;
    List<int> count = new List<int>();
    public List<AudioClip> se;
    AudioSource aud;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        aud = GetComponent<AudioSource>();
        for (int i = 0; i <= 10; i++)
        {
            count.Add(PlayerPrefs.GetInt("count"+i));
            try
            {
                text[i].GetComponent<TextMeshProUGUI>().text = addzeros(count[i]);
            }
            catch
            {
                Debug.Log("cancel");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    static string addzeros(int number)
    {
        string value="";
        if (number < 0)
        {
            value = "-00" + (-1*number).ToString();
        }
        else if (number < 10)
        {
            value = "000" + number.ToString();
        }
        else if (number < 100)
        {
            value = "00" + number.ToString();
        }
        else if (number < 1000)
        {
            value = "0" + number.ToString();
        }
        else if (number < 10000)
        {
            value = "" + number.ToString();
        }
        return value;
    }

    public void count_up(int num)
    {
        aud.PlayOneShot(se[0]);
        count[num] += 1;
        text[num].GetComponent<TextMeshProUGUI>().text = addzeros(count[num]);
    }
    public void count_minus(int num)
    {
        aud.PlayOneShot(se[0]);
        count[num] -= 1;
        text[num].GetComponent<TextMeshProUGUI>().text = addzeros(count[num]);
    }
    public void count_reset(int num)
    {
        aud.PlayOneShot(se[0]);
        count[num] = 0;
        text[num].GetComponent<TextMeshProUGUI>().text = addzeros(count[num]);
    }
    public void plus_all()
    {
        for (int i = 0; i < 10; i++)
        {
            count_up(i);
        }
    }
    public void minus_all()
    {
        for (int i = 0; i < 10; i++)
        {
            count_minus(i);
        }
    }
    public void reset_all()
    {
        for (int i = 0; i < 10; i++)
        {
            count_reset(i);
        }
    }
    private void OnApplicationFocus(bool focus)
    {

        if (focus == false)
        {
            for (int i = 0; i <= 10; i++)
            {
                PlayerPrefs.SetInt("count" + i,count[i]);
            }
            PlayerPrefs.Save();
        }
    }
}
