using UnityEngine;

[CreateAssetMenu]
public class Hero : ScriptableObject
{
    public int MaxHealth;

    public int CurrentHealth;

    public Elements Element;

    public void Copy(Hero hero)
    {
        MaxHealth = hero.MaxHealth;
        CurrentHealth = hero.CurrentHealth;
        Element = hero.Element;
    }
}