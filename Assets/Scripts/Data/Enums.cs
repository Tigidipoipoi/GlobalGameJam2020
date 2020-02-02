using System;
using UnityEngine;

public enum Elements
{
    FIRE,
    PLANT,
    AIR,
    THUNDER,
    WATER
}

public enum Damages
{
    INTACT,
    DAMAGED,
    DESTROYED
}

[Flags]
public enum Slots
{
    CORE = 1,
    ARM_R = 1 << 1,
    ARM_L = 1 << 2,
    LEG_R = 1 << 3,
    LEG_L = 1 << 4,
    EYE = 1 << 5
}

public enum Qualities
{
    PORCELAIN,
    TERRACOTTA,
    IRON,
    GOLD
}
