using UnityEngine;

public interface ICommand
{
    void Execute();
}

public abstract class WeaponCommand : ICommand
{
    protected readonly Weapons curWeapon;

    protected WeaponCommand( Weapons _weapon)
    {
        this.curWeapon = _weapon;
    }

    public abstract void Execute();

    public static T Create<T>(Weapons _weapon) where T : WeaponCommand {
        return (T) System.Activator.CreateInstance(typeof(T), _weapon);
    }
}