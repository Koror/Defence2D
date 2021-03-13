using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private InputField[] inputFields;
    private string[] prefsKeys = {"PlayerHealth", "PlayerDamage",
                                  "EnemyHealth", "EnemyDamage","EnemySpeed","Frequency"};
    private void Start()
    {
        for(int i=0;i<inputFields.Length;i++)
        {
            if(PlayerPrefs.HasKey(prefsKeys[i]))
                inputFields[i].text = PlayerPrefs.GetFloat(prefsKeys[i]).ToString();
        }
    }
    public void PlayButton()
    {
        for (int i = 0; i < inputFields.Length; i++)
        {
            if(!string.IsNullOrEmpty(inputFields[i].text))
                PlayerPrefs.SetFloat(prefsKeys[i], float.Parse(inputFields[i].text));
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }
}
