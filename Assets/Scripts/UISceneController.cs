using UnityEngine;
using System.Collections;
using System.Linq;

public class UISceneController : MonoBehaviour {

    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject winAward;

	// Use this for initialization
	void Start() {
    }
	

	public void Restart() {
		Application.LoadLevel("Lvl1");
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
}
