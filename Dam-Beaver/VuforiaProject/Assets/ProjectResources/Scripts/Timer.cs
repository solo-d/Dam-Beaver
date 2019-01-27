using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private float timeDelay = 3.0f;

    void Start()
    {
        timer = mainTimer;
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        if (timeDelay >= 0)
        {
            timeDelay -= Time.deltaTime;
            return;
        }
        else
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                uiText.text = timer.ToString("F") + " sec";
            }

            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                uiText.text = "0.00 sec";
                timer = 0.0f;
                GameOver();
            }
        }
    }

    void StartTimer()
    {
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void GameOver()
    {
        //Load a new scene
    }
}