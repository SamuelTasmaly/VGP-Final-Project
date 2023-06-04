using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lapCounter : MonoBehaviour
{
    public TextMeshProUGUI lapcountText;
    public TextMeshProUGUI helpText;
    public float lapCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            helpText.gameObject.SetActive(false);
            lapcountText.gameObject.SetActive(true);
            lapCount++;
            lapcountText.text = "Lap: "+ lapCount + "/3";
            if (lapCount > 3)
            {
                lapCount = 1;
                lapcountText.text = "Lap: " + lapCount + "/3";
            }
        }

    }
}
