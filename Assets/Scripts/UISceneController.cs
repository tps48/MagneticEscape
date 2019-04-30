using UnityEngine;
using System.Collections;
using System.Linq;

public class UISceneController : MonoBehaviour {

    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject winAward;
    [SerializeField] private GameObject text;
    private bool showing = false;

	// Use this for initialization
	void Start() {
        text.SetActive(showing);
    }
	

	public void Restart() {
		Application.LoadLevel("Tutorial Level");
	}

    public void QuitGame(){
        Application.Quit();
    }

    public void ChangeSize(string newSizeString) {
        string[] newSize = newSizeString.Split(',');
        PlayerPrefs.SetInt("ySize", int.Parse(newSize[0]));
        PlayerPrefs.SetInt("xSize", int.Parse(newSize[1]));
        Restart();
    }

    public void ShowText()
    {
        showing = !showing;
        text.SetActive(showing);
    }
}
