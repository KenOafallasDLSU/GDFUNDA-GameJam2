using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
  [SerializeField] private Text winText;
  [SerializeField] private Text loseText;
  void Start()
  {
    winText.gameObject.SetActive(false);
    loseText.gameObject.SetActive(false);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnWinEvent);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_LOSE, this.OnLoseEvent);
  }

  private void OnWinEvent()
  {
    winText.gameObject.SetActive(true);
  }

  private void OnLoseEvent()
  {
    loseText.gameObject.SetActive(true);
  }
}