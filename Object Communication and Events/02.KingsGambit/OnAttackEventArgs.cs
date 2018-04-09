using System;public class OnAttackEventArgs : EventArgs
{
    public string Name { get; private set; }

    public OnAttackEventArgs(string name)
    {
        this.Name = name;
    }
}
