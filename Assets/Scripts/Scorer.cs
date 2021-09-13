using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
  [SerializeField] private Text scoreText;
  [SerializeField] private int dirtyObjects = 0;

  void Awake()
  {
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_CLEAN, this.OnCleanEvent);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_DIRTY, this.OnDirtyEvent);
  }
  void Start()
  {
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnGameEndEvent);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_LOSE, this.OnGameEndEvent);

    this.scoreText.text = "Dirty: " + dirtyObjects.ToString();

    scoreText.gameObject.SetActive(true);
  }

  private void OnDestroy()
  {
      EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_WIN);
      EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_LOSE);
      EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_CLEAN);
      EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam2.ON_DIRTY);
  }

  private void OnGameEndEvent()
  {
    scoreText.gameObject.SetActive(false);
  }

  private void OnCleanEvent()
  {
    dirtyObjects -= 1;
    Debug.Log("Dirt:"+dirtyObjects);
    scoreText.text = "Dirty: " + dirtyObjects.ToString();

    if(dirtyObjects == 0)
    {
      EventBroadcaster.Instance.PostEvent(EventNames.GameJam2.ON_WIN);
      Debug.Log("YOU WIN!");
    }
  }

  private void OnDirtyEvent()
  {
    dirtyObjects += 1;
    Debug.Log("Dirt:"+dirtyObjects);
    scoreText.text = "Dirty: " + dirtyObjects.ToString();
  }
}