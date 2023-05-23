using System.Threading.Tasks;
using Game.Scripts.Infrastructure.Services;

namespace Game.Scripts.UI.Services.Factory
{
	public interface IUIFactory : IService
	{
		void CreateShop();
		Task CreateUIRoot();
	}

}