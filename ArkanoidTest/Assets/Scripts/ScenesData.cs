using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Database")]
public class ScenesData : ScriptableObject
{
    public List<Level> levels = new List<Level>();
    public List<Menu> menus = new List<Menu>();
    public int CurrentLevelIndex = 1;

    /*
 	* Уровни
 	*/

    // Загружаем сцену с заданным индексом
    public void LoadLevelWithIndex(int index)
    {
        if (index <= levels.Count)
        {
            // Загружаем сцену геймплея для уровня
            SceneManager.LoadSceneAsync("Gameplay" + index.ToString());
            // Загружаем первую часть уровня в аддитивном режиме
            SceneManager.LoadSceneAsync("Level" + index.ToString() + "Part1", LoadSceneMode.Additive);
        }
        // сбрасываем индекс, если у нас больше нет уровней
        else CurrentLevelIndex = 1;
    }
    // Запуск следующего уровня
    public void NextLevel()
    {
        CurrentLevelIndex++;
        LoadLevelWithIndex(CurrentLevelIndex);
    }
    // Перезапускаем текущий уровень
    public void RestartLevel()
    {
        LoadLevelWithIndex(CurrentLevelIndex);
    }
    // Новая игра, загрузка первого уровня
    public void NewGame()
    {
        LoadLevelWithIndex(1);
    }

    /*
 	* Меню
    */

    // Загрузить главное меню
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(menus[(int)Type.Main_Menu].sceneName);
    }
    // Загрузить меню паузы
    public void LoadPauseMenu()
    {
        SceneManager.LoadSceneAsync(menus[(int)Type.Pause_Menu].sceneName);
    }
}
