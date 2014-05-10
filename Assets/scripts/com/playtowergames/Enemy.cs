using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Enemy  {

    public EnemyTypesEnum Type;
    public float MinSpeed = .2f;
    public float MaxSpeed = 1.4f;
    public GameObject EnemyPrefab;

}
