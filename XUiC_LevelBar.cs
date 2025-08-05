namespace LWFBars
{
    class XUiC_LevelBar : XUiC_ToolbeltWindow
    {
        private readonly CachedStringFormatterInt LevelFormatter = new();

        private readonly CachedStringFormatterInt SkillPointsFormatter = new();
 
        public override bool GetBindingValue(ref string value, string bindingName)
        {
            switch (bindingName)
            {
                case "playerlevel":
                    if (localPlayer != null)
                    {
                        value = LevelFormatter.Format(localPlayer.Progression.GetLevel());
                    }
                    return true;
                case "skillpoints":
                    if (localPlayer != null)
                    {
                        value = SkillPointsFormatter.Format(localPlayer.Progression.SkillPoints);
                    }
                    return true;
                case "skillpointsvisible":
                    value = (localPlayer != null && localPlayer.Progression.SkillPoints > 0).ToString();
                    return true;
            }
            return base.GetBindingValue(ref value, bindingName);
        }
    }
}
