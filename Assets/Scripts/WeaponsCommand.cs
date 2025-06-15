using UnityEngine;
public class FireCommand : WeaponCommand
{
    public FireCommand(IWeapons _weapon) : base(_weapon) { }

    public override void Execute()
    {
        curWeapon.Fire();
    }

}
public class ReloadCommand : WeaponCommand
{
    public ReloadCommand(IWeapons _weapon) : base(_weapon) { }

    public override void Execute()
    {
        curWeapon.Reload();
    }

}