using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
  [SerializeField] private Text scoreText;
  private int dirtyObjects = 0;

  void Awake(){
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_CLEAN, this.OnCleanEvent);
    EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_DIRTY, this.OnDirtyEvent);
  }

  private void OnCleanEvent()
  {
    dirtyObjects -= 1;
    Debug.Log("Dirt:"+dirtyObjects);
    scoreText.text = dirtyObjects.ToString();

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
    scoreText.text = dirtyObjects.ToString();
  }
}