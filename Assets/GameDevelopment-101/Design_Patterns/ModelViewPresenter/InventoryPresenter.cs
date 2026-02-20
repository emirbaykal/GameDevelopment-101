namespace GameDevelopment_101.Design_Patterns.ModelViewPresenter
{
    public class InventoryPresenter
    {
        private InventoryModel _model;
        private InventoryView _view;
        
        public InventoryPresenter(InventoryModel model, InventoryView view)
        {
            _model = model;
            _view = view;

            _view.OnAddGoldClicked += HandleAddGold;

            RefreshView();
        }

        private void HandleAddGold()
        {
            _model.AddGold(10);
            RefreshView();
        }

        private void RefreshView()
        {
            _view.UpdateGoldDisplay(_model.Gold);
        }
    }
}