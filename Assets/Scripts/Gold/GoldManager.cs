namespace Gold
{
    public class GoldManager 
    {
        private static GoldManager _instance;
        public static GoldManager Instance => _instance ??= new GoldManager();

        public void Sell()
        {
            throw new System.NotImplementedException();
        }

        public void AddReward(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}
