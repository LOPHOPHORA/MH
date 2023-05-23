using System.Threading.Tasks;
using Game.Scripts.Infrastructure.AssetManagement;
using Game.Scripts.Infrastructure.Services.PersistentProgress;
using Game.Scripts.Infrastructure.Services.StaticData;
using Game.Scripts.StaticData.Windows;
using Game.Scripts.UI.Services.Window;
using Game.Scripts.UI.Windows;
using UnityEngine;

namespace Game.Scripts.UI.Services.Factory
{
	public class UIFactory : IUIFactory
	{
		private const string UIRootPath = "UIRoot";
		private readonly IAssets _assets;
		private readonly IStaticDataService _staticData;
		private readonly IPersistentProgressService _progressService;

		private Transform _uiRoot;

		public UIFactory(IAssets assets, IStaticDataService staticData, IPersistentProgressService progressService)
		{
			_assets = assets;
			_staticData = staticData;
			_progressService = progressService;
		}

		public void CreateShop()
		{
			WindowConfig config = _staticData.ForWindow(WindowId.Shop);
			WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
			window.Construct(_progressService);
		}
		
		public async Task CreateUIRoot()
		{
			GameObject root = await _assets.Instantiate(UIRootPath);
			_uiRoot = root.transform;
		}
	}
}