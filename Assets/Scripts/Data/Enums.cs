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
    ARM_1 = 1 << 1,
    ARM_2 = 1 << 2,
    LEG_1 = 1 << 3,
    LEG_2 = 1 << 4,
    EYE = 1 << 5
}

public enum Qualities
{
    EARTHENWARE,
    PORCELAIN,
    TERRACOTTA,
    SANDSTONE,
    ROCK,
    IRON,
    DIAMOND
}
