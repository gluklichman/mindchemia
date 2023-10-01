namespace Assets.Scripts.Data
{
    public class Data
    {
        public static Configs Configs;
        public static WordMatchData WordMatchData;

        public Data()
        {
            Configs = new Configs();
            WordMatchData = new WordMatchData();
        }
    }
}