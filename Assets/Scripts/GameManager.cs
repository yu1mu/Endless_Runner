using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stagePoint;

    public Text UIPoint;
    public Text UIStage;

    private string sceneName;
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }
    private void Update()
    {
        UIPoint.text = stagePoint.ToString();
        UIStage.text = sceneName;
    }
    public void NextStage()
    {

        if (sceneName == "Stage1")
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (sceneName == "Stage2")
        {
            SceneManager.LoadScene("Start");
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }

}
