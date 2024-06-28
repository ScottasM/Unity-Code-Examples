using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TileScriptable
{
    public int id;
    public string name;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObjects/TileDatabase")]
public class TileDatabase : ScriptableObject
{
    public List<TileScriptable> tiles;
}
