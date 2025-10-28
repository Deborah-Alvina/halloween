using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public Text scoretext;
    public GameObject gameOverScene;
    public GameObject youWonScene;

    private ParentGhostHandler gh;

    void Start()
    {
        gh = FindObjectOfType<ParentGhostHandler>();
    }

    void Update()
    {
        if (gh != null && scoretext != null)
        {
            scoretext.text = gh.points.ToString();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScene.SetActive(true);
    }

    public void youWon()
    {
        youWonScene.SetActive(true);
    }
}