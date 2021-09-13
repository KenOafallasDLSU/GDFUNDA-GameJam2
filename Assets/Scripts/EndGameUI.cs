using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
  [SerializeField] private Text winText;
  [SerializeField] private Text loseText;
  [SerializeField] private Image winImage;
  [SerializeField] private Image loseImage;
  [SerializeField] private Button exit;
  [SerializeField] private Button tryAgain;
  void Start()
  {
    winText.gameObject.SetActive(false);
    loseText.gameObject.SetActive(false);

    winImage.gameObject.SetActive(false);
    loseImage.gameObject.SetActive(false);
    exit.gameObject.SetActive(false);
    tryAgain.gameObject.SetActive(false);

    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnWinEvent);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_LOSE, this.OnLoseEvent);
  }

  private void OnWinEvent()
  {
    //winText.gameObject.SetActive(true);
    winImage.gameObject.SetActive(true);
    exit.gameObject.SetActive(true);
    tryAgain.gameObject.SetActive(true);
  }

  private void OnLoseEvent()
  {
    //loseText.gameObject.SetActive(true);
    loseImage.gameObject.SetActive(true);
    exit.gameObject.SetActive(true);
    tryAgain.gameObject.SetActive(true);
  }
}