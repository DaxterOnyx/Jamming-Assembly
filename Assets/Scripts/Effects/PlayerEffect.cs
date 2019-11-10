﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerEffect : Effect
{
	public int value;
    public abstract void OnEquip();
    public abstract void OnUnequip();
}
