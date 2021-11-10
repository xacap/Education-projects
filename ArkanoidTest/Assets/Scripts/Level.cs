using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
public class Level : GameScene
{
    // Настройки, относящиеся только к уровню
    [Header("Level specific")]
    public int enemiesCount;
}
