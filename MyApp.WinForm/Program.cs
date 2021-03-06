﻿using MyApp.WinForm.Launcher.Presenter;
using System;
using System.Windows.Forms;
using MyApp.WinForm.Windsor.Bootstrapper;
using MyApp.WinForm.Windsor;

namespace MyApp.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var container = GlobalContainerAccessor.Instance.Container)
            {
                container.Register(
                    new MainBootstrapper(), 
                    new ViewBootstrapper());

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var presenter = container.Resolve<LauncherPresenter>();
                var form = (Form)presenter.Form;

                Application.Run(form);
            }
        }
    }
}
