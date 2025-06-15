using UnityEngine;
using System.Collections.Generic;
public class CommandManager : MonoBehaviour
{
    [SerializeField] PlayerWeaponChange pwc;

    public IWeapons weapon;
    [SerializeField] public Stack<ICommand> commands = new();

    readonly CommandInvoker commandInvoker = new();

    private void Start()
    {
        GameObject wobj = pwc.ProvideCurWeapon();
        weapon = wobj.GetComponent<IWeapons>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            commands.Push(new ReloadCommand(weapon));
            ExecuteCommands(commands.Peek());
        }
        if (Input.GetMouseButton(0))
        {
            commands.Push(new FireCommand(weapon));
            ExecuteCommands(commands.Peek());
        }
        GetCurWeapon();
    }

    void GetCurWeapon()
    {
        GameObject wobj = pwc.ProvideCurWeapon();
        weapon = wobj.GetComponent<IWeapons>();
    }

    void ExecuteCommands(ICommand command)
    {
        commandInvoker.ExecuteCommand(command);
    }
}

public class CommandInvoker
{
    public void ExecuteCommand(ICommand _command)
    {
        _command.Execute();       
    }
}