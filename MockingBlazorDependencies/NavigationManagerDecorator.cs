using Microsoft.AspNetCore.Components;
using System;

namespace MockingBlazorDependencies
{
	public sealed class NavigationManagerDecorator
		: INavigationManager
	{
		private readonly NavigationManager manager;

		public NavigationManagerDecorator(NavigationManager manager) =>
			this.manager = manager ?? throw new ArgumentNullException(nameof(manager));

		public void NavigateTo(string uri) => 
			this.manager.NavigateTo(uri);
	}
}
