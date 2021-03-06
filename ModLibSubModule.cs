﻿using ModLib.Debugging;
using ModLib.GUI.GauntletUI;
using System;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace ModLib
{
    public class ModLibSubModule : MBSubModuleBase
    {
        public static string ModuleFolderName { get; } = "ModLib";

        protected override void OnSubModuleLoad()
        {
            try
            {
                FileDatabase.Initialise(ModuleFolderName);

                Module.CurrentModule.AddInitialStateOption(new InitialStateOption("ModOptionsMenu", new TextObject("Mod Options"), 9990, () =>
                {
                    ScreenManager.PushScreen(new ModOptionsGauntletScreen());
                }, false));
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                ModDebug.ShowError($"An error occurred whilst initialising ModLib", "Error during initialisation", ex);
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            SettingsDatabase.BuildModSettingsVMs();
        }
    }
}
