using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CleanOnClick : MonoBehaviour
{
    private Material[] materials;
    private Material dirtyMaterial;
    private int dirtIndex;
    private bool cleanable;
    private bool gameOver = false;

    void Start()
    {
      EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_WIN, this.OnGameOverEvent);
      EventBroadcaster.Instance.AddObserver(EventNames.GameJam2.ON_LOSE, this.OnGameOverEvent);

      materials = gameObject.GetComponent<Renderer>().materials;
      dirtIndex = materials.Length - 1;
      dirtyMaterial = materials[dirtIndex];

      cleanable = true;

      ChangeOpacity(0.6f);
      EventBroadcaster.Instance.PostEvent(EventNames.GameJam2.ON_DIRTY);
      this.StartCoroutine(this.MakeDirty());
    }

    void OnMouseDown()
    {
      if(cleanable && !gameOver)
        this.StartCoroutine(this.MakeClean());
    }

    private IEnumerator MakeClean()
    {
        cleanable = false;

        if(dirtyMaterial.color.a == 0.6f)
        {
          ChangeOpacity(0.3f);
        }
        else if(dirtyMaterial.color.a == 0.3f)
        {
          ChangeOpacity(0.0f);
          EventBroadcaster.Instance.PostEvent(EventNames.GameJam2.ON_CLEAN);
        }

        yield return new WaitForSeconds(2);
        cleanable = true;
    }

    private IEnumerator MakeDirty()
    {
        yield return new WaitForSeconds(Random.Range(8, 14));

        if(gameOver == false){
          if(dirtyMaterial.color.a == 0.3f)
          {
            ChangeOpacity(0.6f);
          }
          else if(dirtyMaterial.color.a == 0.0f)
          {
            ChangeOpacity(0.3f);
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam2.ON_DIRTY);
          }

          this.StartCoroutine(this.MakeDirty());
        }
    }

    private void ChangeOpacity(float opacity)
    {
      Color color = dirtyMaterial.color;
      Color newColor = new Color(color.r, color.g, color.b, opacity);
      dirtyMaterial.color = newColor;
    }

    private void OnGameOverEvent()
    {
      gameOver = true;
    }
}