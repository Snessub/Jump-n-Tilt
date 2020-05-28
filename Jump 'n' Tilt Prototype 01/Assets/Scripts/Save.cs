﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Structure for the Saves. Can be serialized and turned into binary files. Attributes represent the saved data. Currently just a list
* of IDs of gathered Collectibles
*
* @Katja
*/
[System.Serializable]
public class Save
{
    public List<int> collectiblesGathered = new List<int>();
}
