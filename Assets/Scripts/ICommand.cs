using UnityEngine;

public interface ICommand
{
    void Execute();
}

public abstract class WeaponCommand : ICommand
{
    protected readonly IWeapons curWeapon;

    protected WeaponCommand( IWeapons _weapon)
    {
        this.curWeapon = _weapon;
    }

    public abstract void Execute();

    public static T Create<T>(IWeapons _weapon) where T : WeaponCommand {
        return (T) System.Activator.CreateInstance(typeof(T), _weapon);
    }
}