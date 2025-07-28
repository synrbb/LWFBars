using System;

namespace LWFBars
{
    public class XUiC_FoodWaterBar : XUiC_HUDStatBar
    {
        private readonly CachedStringFormatter<int, int> FoodFormatter = new((a, b) => $"{a}/{b}");

        private readonly CachedStringFormatter<int, int> WaterFormatter = new((a, b) => $"{a}/{b}");

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
                            value = FoodFormatter.Format((int)Math.Round(stat.Value), (int)Math.Round(stat.Max));
                        }
                        return true;
                    case HUDStatTypes.Water:
                        if (LocalPlayer != null)
                        {
                            Stat stat = LocalPlayer.Stats.Water;
                            value = WaterFormatter.Format((int)Math.Round(stat.Value), (int)Math.Round(stat.Max));
                        }
                        return true;
                }
            }
            return base.GetBindingValue(ref value, bindingName);
        }
    }
}
