using FoodOrdersContracts.BindingModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IBackUpLogic
    {
        void CreateBackUp(BackUpSaveBinidngModel model);
    }
}