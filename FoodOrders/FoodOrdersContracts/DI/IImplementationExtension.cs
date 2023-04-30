namespace FoodOrdersContracts.DI
{
    public interface IImplementationExtension
	{
		public int Priority { get; }
		/// <summary>
		/// Регистрация сервисов
		/// </summary>
		public void RegisterServices();
	}
}