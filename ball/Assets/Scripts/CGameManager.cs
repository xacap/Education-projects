using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static CGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CGameManager>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("CGameManager");
                    instance = instanceContainer.AddComponent<CGameManager>();
                }
            }
            return instance;
        }
    }
    private static CGameManager instance;

    [SerializeField] GameObject StageManager;
    [SerializeField] GameObject Player;

    public PlayerController mPlayerController;
    public StageManager mStageManager;

    public CEvents mNotificationManager = null;
    public CGUIManager mGUIManager = null;

    public CEvents GetNotificationManager()
    {
        return mNotificationManager;
    }

    private void Awake()
    {
        Initialization();
        mNotificationManager.Register(EEventType.eRestartGameEvent, IsGameFinished);
    }
    void Start()
    {
        mPlayerController = Player.GetComponent<PlayerController>();
        mStageManager = StageManager.GetComponent<StageManager>();
    }
    private void Initialization()
    {
        mNotificationManager = new CEvents();
        mGUIManager = this.transform.GetComponent<CGUIManager>();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
    public void IsGameFinished()
    {
        mGUIManager.ShowGameFinishWindow();
        Time.timeScale = 0f;
    }

}
