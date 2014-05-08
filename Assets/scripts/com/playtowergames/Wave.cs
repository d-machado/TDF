using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Wave {

    public EnemyType TypeOfEnemies;
    public int AmountOfEnemies = 3;
    public float StartTime = 15f;
    
}

public enum EnemyType
{
    ENEMY_1,
    ENEMY_2
}
