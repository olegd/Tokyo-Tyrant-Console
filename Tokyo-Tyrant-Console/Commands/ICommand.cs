// *******************************************************************************
// * Copyright (c) 1999 - 2011.
// * Global Relay Communications Inc.
// * All rights reserved.
// *******************************************************************************

namespace Tokyo_Tyrant_Console.Commands
{
    public interface ICommand
    {
        void Invoke(CommandOptions options);
    }
}