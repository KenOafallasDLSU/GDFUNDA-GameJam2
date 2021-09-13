using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Image toDo;
    [SerializeField] private Image howTo;
    [SerializeField] private Button start;
    [SerializeField] private Button exit;
    [SerializeField] private Button next;
    [SerializeField] private Button play;

    void Start()
    {
        toDo.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
    }

    public void showToDo()
    {
        start.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        toDo.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
    }

    public void showHowTo()
    {
        toDo.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        howTo.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
    }

}
