using System;
using Components_Namespace;
using Core;

namespace Commands;

public record Over_Time_Command(int Times, int Time_Between, Components Target, int Amount, string Name) : Command
{
    public Timer_Component Timer { get; set; }
    public int Runs { get; set; }
}
