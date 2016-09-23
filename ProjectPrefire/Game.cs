﻿using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;

namespace ProjectPrefire
{
	public class Game
	{
		public List<Player> players { get; set;}
		public Map map {get; set;}
		public Game (List<string[]> csvRows, Map map)
		{
			this.map = map;
			//TODO This might not be the most suitable place.
			#region csv parsing
			//TODO Instead of using the dictionary class to sort rows, Distinct() may offer a better solution.
			Dictionary<string, Player> playerDictionary = new Dictionary<string, Player> ();
			foreach(var row in csvRows)
			{
				if (playerDictionary.ContainsKey (row [5])) {
					Player p = playerDictionary [row [5]];
					p.playerStates.Add (new PlayerState (
						float.Parse (row [1]), 
						float.Parse (row [2]),
						float.Parse (row [3]),
						float.Parse (row [4]),
						int.Parse (row [0])));
				} else {
					Player p = new Player (int.Parse(row [5]), int.Parse(row [6]));
					p.playerStates.Add (new PlayerState (
						float.Parse (row [1]), 
						float.Parse (row [2]),
						float.Parse (row [3]),
						float.Parse (row [4]),
						int.Parse (row [0])));
					playerDictionary.Add (row [5], p);
				}
			}
			players = playerDictionary.Values.ToList();
			#endregion
		}
	}
}

