using System;

namespace MockingBlazorDependencies
{
	public sealed class UsesINavigationManager
	{
		private readonly INavigationManager manager;

		public UsesINavigationManager(INavigationManager manager) =>
			this.manager = manager ?? throw new ArgumentNullException(nameof(manager));

		public void Use() =>
			this.manager.NavigateTo("/NewRoute");
	}
}