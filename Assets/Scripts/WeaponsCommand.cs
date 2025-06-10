using UnityEngine;
public class FireCommand : WeaponCommand
{
    public FireCommand(Weapons _weapon) : base(_weapon) { }

    public override void Execute()
    {
        curWeapon.Fire();
    }

}
public class ReloadCommand : WeaponCommand
{
    public ReloadCommand(Weapons _weapon) : base(_weapon) { }

    public override void Execute()
    {
        curWeapon.Reload();
    }

}