using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }

    public void StartGame()
    {
        // Yazýlan ismi Instance aracýlýðýyla kaydet
        DataManager.Instance.currentPlayerName = nameInput.text;

        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
