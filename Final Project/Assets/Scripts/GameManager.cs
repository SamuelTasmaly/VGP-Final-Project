using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   public TextMeshProUGUI lapcountText;
    public GameObject checkPoint;
    public float lap = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lap++;
            lapcountText.text = "Lap: " + lap + "/3";
        }

    }
        
    }
}
