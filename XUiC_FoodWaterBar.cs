using System;

namespace LWFBars
{
    public class XUiC_FoodWaterBar : XUiC_HUDStatBar
    {
        public override void Update(float _dt)
        {
            base.Update(_dt);

            if ((StatType == HUDStatTypes.Food || StatType == HUDStatTypes.Water)
                && LocalPlayer.IsDead()
                && ViewComponent.IsVisible)
            {
                RefreshBindings(_forceAll: true);
            }
        }

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
                            value = statcurrentWMaxFormatterAOfB.Format(
                                (int)Math.Round(stat.Value, MidpointRounding.AwayFromZero),
                                (int)Math.Round(stat.Max, MidpointRounding.AwayFromZero));
                        }
                        return true;
                    case HUDStatTypes.Water:
                        if (LocalPlayer != null)
                        {
                            Stat stat = LocalPlayer.Stats.Water;
                            value = statcurrentWMaxFormatterAOfB.Format(
                                (int)Math.Round(stat.Value, MidpointRounding.AwayFromZero),
                                (int)Math.Round(stat.Max, MidpointRounding.AwayFromZero));
                        }
                        return true;
                }
            }
            return base.GetBindingValue(ref value, bindingName);
        }
    }
}
