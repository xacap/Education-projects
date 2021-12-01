using UnityEngine;
using UnityEngine.UI;

public class CWindowGameFinish : MonoBehaviour
{
    void Start()
    {
        GameObject panel = gameObject.transform.Find("PanelButton").gameObject;

        
        GameObject buttonNextObj = panel.transform.Find("ButtonNext").gameObject;
        Button buttonNext = buttonNextObj.GetComponent<Button>();
        buttonNext.onClick.AddListener(() => NextLevelButton());
    }

    public void NextLevelButton()
    {
        CGameManager.Instance.SwitchScene("GameScene");
        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }
}