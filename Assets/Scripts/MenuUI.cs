using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    [SerializeField] private TMP_InputField inputField;

    public void OnClickStart() {

        DataManager.Instance.playerName = inputField.text;

        SceneManager.LoadScene(1);
    }
}
