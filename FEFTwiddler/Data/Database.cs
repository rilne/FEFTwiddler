﻿namespace FEFTwiddler.Data
{
    public static class Database
    {
        public static CharacterDatabase Characters = new CharacterDatabase(Enums.Language.English);
        public static ClassDatabase Classes = new ClassDatabase(Enums.Language.English);
        public static ItemDatabase Items = new ItemDatabase(Enums.Language.English);
        public static SkillDatabase Skills = new SkillDatabase(Enums.Language.English);
        public static BuildingDatabase Buildings = new BuildingDatabase(Enums.Language.English);
        public static StatDatabase Stats = new StatDatabase(Enums.Language.English);

        public static void SetLanguage(Enums.Language language)
        {
            Characters.SetLanguage(language);
            Classes.SetLanguage(language);
            Items.SetLanguage(language);
            Skills.SetLanguage(language);
            Buildings.SetLanguage(language);
            Stats.SetLanguage(language);
        }
    }
}
