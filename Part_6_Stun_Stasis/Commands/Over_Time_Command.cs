using System;
using Core;
using Interfaces;

namespace Commands;

public record Over_Time_Command(IOver_Timer_Model Model, Command Command, Func<bool> Can_Run)
    : Command
{
}
