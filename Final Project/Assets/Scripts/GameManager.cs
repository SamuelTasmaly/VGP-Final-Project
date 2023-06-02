using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   public TextMeshProUGUI lapcountText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI helpText;
    public TextMeshProUGUI controlsText;
    public Button backButton;
    public Button controlsButton;
    public GameObject checkPoint;
    public Button startButton;
    public float lap = 0;
    public Camera interiorCamera;
    public Camera exteriorCamera;
    // camera true is exteroir, camera false is interior
    public bool cameraAngle;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

        Button ctrlbtn = controlsButton.GetComponent<Button>();
        ctrlbtn.onClick.AddListener(contrls);

        Button bckbtn = backButton.GetComponent<Button>();
        bckbtn.onClick.AddListener(backs);
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

    if (Input.GetKeyDown("z"))
    {
        interiorCameraView();
    }
    if (Input.GetKeyDown("x"))
    {
        
        exteriorCameraView();
    }
    }
        
    

    public void exteriorCameraView()
    {
        exteriorCamera.enabled = true;
        interiorCamera.enabled = false;

    }

    public void interiorCameraView()
    {
        exteriorCamera.enabled = false;
        interiorCamera.enabled = true;
    }
    void TaskOnClick(){
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        helpText.gameObject.SetActive(true);
    }

    void contrls(){
        controlsText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        controlsButton.gameObject.SetActive(false);
    }

    void backs(){
        
    }
}
