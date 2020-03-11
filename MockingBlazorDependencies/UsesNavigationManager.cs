using Microsoft.AspNetCore.Components;
using System;

namespace MockingBlazorDependencies
{
	public sealed class UsesNavigationManager
	{
		private readonly NavigationManager manager;

		public UsesNavigationManager(NavigationManager manager) =>
			this.manager = manager ?? throw new ArgumentNullException(nameof(manager));

		public void Use() =>
			this.manager.NavigateTo("/NewRoute");
	}
}