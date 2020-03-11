using Microsoft.AspNetCore.Components;
using NUnit.Framework;
using Rocks;
using System;

namespace MockingBlazorDependencies.Tests
{
	public static class UsesNavigationManagerTests
	{
		[Test]
		public static void Create() =>
			Assert.That(() => new UsesNavigationManager(Rock.Make<NavigationManager>()), Throws.Nothing);

		[Test]
		public static void CreateWithNullManager() =>
			Assert.That(() => new UsesNavigationManager(null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void CallUse()
		{
			var manager = new MockNavigationManager();
			var uses = new UsesNavigationManager(manager);
			uses.Use();

			Assert.That(manager.WasNavigateInvoked, Is.True);
		}

		public sealed class MockNavigationManager
			: NavigationManager
		{
			public MockNavigationManager() : base() => 
				this.Initialize("http://localhost:2112/", "http://localhost:2112/test");

			protected override void NavigateToCore(string uri, bool forceLoad) => 
				this.WasNavigateInvoked = true;

			public bool WasNavigateInvoked { get; private set; }
		}
	}
}