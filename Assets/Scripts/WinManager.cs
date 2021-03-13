using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text winText;
    [SerializeField]
    private Text loseText;
    [SerializeField]
    private float finalScore;

    private void Update()
    {
        if (player != null)
        {
            float playerHealth = player.GetComponent<PlayerController>().Health;
            if (playerHealth < 0)
            {
                Destroy(player);
                StartCoroutine(GameOver());
            }
        }
        if(ScoreManager.instance.Score>finalScore)
            StartCoroutine(Win());
    }

    private IEnumerator GameOver()
    {
        loseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuScene");
    }

    private IEnumerator Win()
    {
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuScene");
    }
}
