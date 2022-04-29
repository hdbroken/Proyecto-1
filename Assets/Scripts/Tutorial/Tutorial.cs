using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private string _textOnScreen;

    
    [SerializeField]
    private TutorialName _tutorialName;
    
    [SerializeField]
    private int _tutorialNumber = 0;
        
    public enum TutorialName
    {
        Keyboard,
        Turret,
        Walker,
        Finish
    }

    private TutorialData _tutorial;
    public struct TutorialData
    {
        public TutorialName name;
        public int number;
    }

    private void Awake()    
    {
        _tutorial.name = _tutorialName;
        _tutorial.number = _tutorialNumber;        
    }

    private void Start()
    {
        GameManager.instance.AddTutorial(_tutorial);
    }

    private void Update()
    {
        if(GameManager.instance.tutorialSeen[_tutorial] && Input.GetKeyDown(KeyCode.Space))        
        {
            _panel.SetActive(false);
            this.gameObject.SetActive(false);
            EventManager.onPauseGame?.Invoke(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.tutorialSeen[_tutorial] = true;
            
            _text.text = _textOnScreen;
            _panel.SetActive(true);
            EventManager.onPauseGame?.Invoke(true); 
        }
    }   
    
}
