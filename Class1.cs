using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalBugFix.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalBugFix
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ModBase : BaseUnityPlugin
    {
        private const string modGUID = "Murry.LethalBugFix";
        private const string modName = "Lethal Bug Fix";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ModBase instance;

        ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            logSource.LogInfo(modName + " has AWOKEN!");

            harmony.PatchAll(typeof(ModBase));
            harmony.PatchAll(typeof(LightningPatch));
        }
    }
}