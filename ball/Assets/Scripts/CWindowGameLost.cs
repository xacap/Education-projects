using UnityEngine;
using UnityEngine.UI;


public class CWindowGameLost : MonoBehaviour
{
    void Start()
    {
        GameObject panel = gameObject.transform.Find("PanelButton").gameObject;

        GameObject buttonSelectObj = panel.transform.Find("ButtonSelect").gameObject;
        Button buttonSelect = buttonSelectObj.GetComponent<Button>();
        buttonSelect.onClick.AddListener(() => LevelSelectSceneButton());
    }

    public void LevelSelectSceneButton()
    {
        CGameManager.Instance.LoadScene("GameScene");
        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }
}
