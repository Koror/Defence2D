using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    [SerializeField]
    private Text scoreUI;
    private float currrentScore;
    public float Score
    {
        get { return currrentScore; }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float score)
    {
        currrentScore += score;
        scoreUI.text = "Score: " + currrentScore.ToString();
    }

}
