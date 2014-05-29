using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Content : MonoBehaviour
{
	public static SortedDictionary<StoneType , GameObject> Stones;

	public static SortedDictionary<TinType , GameObject> Tins;

	public static GameObject SlingShot;

	public static void Load()
	{
		SlingShot = Resources.Load("GamePlay/Prefabs/SlingShot") as GameObject;

		Stones = new SortedDictionary<StoneType, GameObject>();

        Stones.Add(StoneType.Small, Resources.Load("GamePlay/Prefabs/Stones/SmallStone") as GameObject);
        Stones.Add(StoneType.Normal, Resources.Load("GamePlay/Prefabs/Stones/NormalStone") as GameObject);
        Stones.Add(StoneType.Big, Resources.Load("GamePlay/Prefabs/Stones/BigStone") as GameObject);

		Tins = new SortedDictionary<TinType, GameObject>();

        Tins.Add(TinType.Small, Resources.Load("GamePlay/Prefabs/Tins/SmallTin") as GameObject);
        Tins.Add(TinType.Normal, Resources.Load("GamePlay/Prefabs/Tins/NormalTin") as GameObject);
        Tins.Add(TinType.Big, Resources.Load("GamePlay/Prefabs/Tins/BigTin") as GameObject);
	}
}