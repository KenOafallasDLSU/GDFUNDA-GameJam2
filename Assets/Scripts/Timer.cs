using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private Text timeText;
    private bool timerIsRunning = false;
    

    private void Start()
    {
        timeText.gameObject.SetActive(true);
        // Starts the timer automatically
        timerIsRunning = true;

        EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnGameEndEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_LOSE, this.OnGameEndEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnWinEvent);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_WIN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_LOSE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_WIN);
    }

    private void OnGameEndEvent()
    {
        timeText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("YOU LOSE!");
                timeRemaining = 0;
                timerIsRunning = false;
                EventBroadcaster.Instance.PostEvent(EventNames.GameJam2.ON_LOSE);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnWinEvent()
    {
      timerIsRunning = false;
    }
}