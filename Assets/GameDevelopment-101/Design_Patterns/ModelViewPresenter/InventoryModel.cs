namespace GameDevelopment_101.Design_Patterns.ModelViewPresenter
{
    public class InventoryModel
    {
        public int Gold { get; set; }
        
        public InventoryModel(int initialGold)
        {
            Gold = initialGold;
        }
        
        public void AddGold(int amount) => Gold += amount;

        public bool RemoveGold(int amount)
        {
            if (Gold < amount) return false;
            Gold -= amount;
            return true;
        }
    }
}