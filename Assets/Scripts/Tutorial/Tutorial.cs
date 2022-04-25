using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private TextMeshProUGUI _text1;

    [SerializeField]
    private string _textTutorial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            EventManager.onPauseGame?.Invoke(true);
            
        }
    }
}
