using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class RoundSettings
{
	public StoneType Stone;
	
	public SortedDictionary<TinType , float> Chances;
	
	public RoundSettings (int Id)
	{
		Chances = new SortedDictionary<TinType, float>();
		
		switch (Id)
		{
			case 0 :
			
			Stone = StoneType.Big;
			
			Chances.Add(TinType.Big , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 1 :
			
			Stone = StoneType.Big;
			
			Chances.Add(TinType.Big , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 2 :
			
			Stone = StoneType.Big;
			
			Chances.Add(TinType.Big , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 3 :
			
			Stone = StoneType.Normal;
			
			Chances.Add(TinType.Normal , 3.0f);
			Chances.Add(TinType.Big , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 4 :
			
			Stone = StoneType.Normal;
			
			Chances.Add(TinType.Normal , 3.0f);
			Chances.Add(TinType.Big , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 5 :
			
			Stone = StoneType.Normal;
			
			Chances.Add(TinType.Normal , 3.0f);
			Chances.Add(TinType.Big , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 6 :
			
			Stone = StoneType.Normal;
			
			Chances.Add(TinType.Normal , 3.0f);
			Chances.Add(TinType.Big , 2.0f);
			Chances.Add(TinType.Small , 1.0f);
			
			break;
			
			case 7 :
			
			Stone = StoneType.Small;
			
			Chances.Add(TinType.Small , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Big , 1.0f);
			
			break;
			
			case 8 :
			
			Stone = StoneType.Small;
			
			Chances.Add(TinType.Small , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Big , 1.0f);
			
			break;
			
			case 9 :
			
			Stone = StoneType.Small;
			
			Chances.Add(TinType.Small , 3.0f);
			Chances.Add(TinType.Normal , 2.0f);
			Chances.Add(TinType.Big , 1.0f);
			
			break;
		}
	}
}