using System;

namespace LWFBars
{
    public class XUiC_FoodWaterBar : XUiC_HUDStatBar
    {
        public override bool GetBindingValue(ref string value, string bindingName)
        {
            if (bindingName == "statcurrentwithmax")
            {
                switch (StatType)
                {
                    case HUDStatTypes.Food:
                        if (LocalPlayer != null)
                        {
                            Stat stat = LocalPlayer.Stats.Food;
                            value = statcurrentWMaxFormatterAOfB.Format((int)Math.Round(stat.Value), (int)Math.Round(stat.Max));
                        }
                        return true;
                    case HUDStatTypes.Water:
                        if (LocalPlayer != null)
                        {
                            Stat stat = LocalPlayer.Stats.Water;
                            value = statcurrentWMaxFormatterAOfB.Format((int)Math.Round(stat.Value), (int)Math.Round(stat.Max));
                        }
                        return true;
                }
            }
            return base.GetBindingValue(ref value, bindingName);
        }
    }
}
