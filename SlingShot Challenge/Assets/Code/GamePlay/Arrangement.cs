using UnityEngine;
using System.Collections;

public enum ArrangementType
{
    Simple , Complex
}

public class Arrangement
{
    GameObject Small , Normal , Big;

    ArrangementType Mode;

    public Arrangement(ArrangementType mode , GameObject small , GameObject normal , GameObject big)
    {
        Mode = mode;

        Small = small;

        Normal = normal;

        Big = big;
    }

    public Arrangement(ArrangementType mode)
    {
        Create();
    }

    public void Create()
    {
        switch (Mode)
        {
            case ArrangementType.Simple:

                Small = GameObject.Instantiate(Content.Tins[TinType.Small], new Vector3(-1.5f, 3.5f, 15), Quaternion.identity) as GameObject;
                Small.name = "SmallTin " + RoundManager.ElapsedRounds;

                Normal = GameObject.Instantiate(Content.Tins[TinType.Normal], new Vector3(0, 3.7f, 15), Quaternion.identity) as GameObject;
                Normal.name = "NormalTin " + RoundManager.ElapsedRounds;

                Big = GameObject.Instantiate(Content.Tins[TinType.Big] , new Vector3(1.5f , 3.8f , 15), Quaternion.identity) as GameObject;
                Big.name = "BigTin " + RoundManager.ElapsedRounds;

                break;

            case ArrangementType.Complex:



                break;
        }
    }

    public void Delete()
    {
        switch (Mode)
        {
            case ArrangementType.Simple:

                GameObject.Destroy(Small);

                GameObject.Destroy(Normal);

                GameObject.Destroy(Big);

                break;

            case ArrangementType.Complex:



                break;
        }
    }
}