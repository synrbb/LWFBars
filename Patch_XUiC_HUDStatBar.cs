using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace LWFBars
{
    [HarmonyPatch(typeof(XUiC_HUDStatBar))]
    class Patch_XUiC_HUDStatBar
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(XUiC_HUDStatBar.HasChanged))]
        static IEnumerable<CodeInstruction> HasChanged(IEnumerable<CodeInstruction> instructions)
        {
            var oldGetter = typeof(Stat).GetProperty(nameof(Stat.ValuePercentUI)).GetGetMethod();
            var newGetter = typeof(Stat).GetProperty(nameof(Stat.Value)).GetGetMethod();
            var statFields = new FieldInfo[]
            {
                typeof(EntityStats).GetField(nameof(EntityStats.Water)),
                typeof(EntityStats).GetField(nameof(EntityStats.Food))
            };

            var codeMatcher = new CodeMatcher(instructions);

            foreach (var statField in statFields)
            {
                for (int i = 0; i < 2; i++)
                {
                    codeMatcher.MatchStartForward(
                            new CodeMatch(OpCodes.Ldfld, statField),
                            new CodeMatch(OpCodes.Callvirt, oldGetter)
                        )
                        .ThrowIfInvalid($"failed to match {i} for {statField}")
                        .InstructionAt(1).operand = newGetter;
                }
            }

            return codeMatcher.Instructions();
        }
    }
}
