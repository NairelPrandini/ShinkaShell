﻿using System;
using System.Threading;
using System.Windows;

namespace ShinkaShell;

public partial class App : Application
{
    private Mutex _singleInstanceMutex;
    protected override void OnStartup(StartupEventArgs e)
    {
        _singleInstanceMutex = new Mutex(true, "ShinkaShell", out bool createdNew);
        if (!createdNew)
        {
            MessageBox.Show("Another instance of ShinkaShell is already running.", "ShinkaShell", MessageBoxButton.OK, MessageBoxImage.Information);
            Current.Shutdown();
        }

        base.OnStartup(e);
    }
}