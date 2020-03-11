using Microsoft.JSInterop;
using NUnit.Framework;
using Rocks;
using System;
using System.Threading.Tasks;

namespace MockingBlazorDependencies.Tests
{
	public static class UsesIJSRuntimeTests
	{
		[Test]
		public static void Create() =>
			Assert.That(() => new UsesIJSRuntime(Rock.Make<IJSRuntime>()), Throws.Nothing);

		[Test]
		public static void CreateWithNullRuntime() =>
			Assert.That(() => new UsesIJSRuntime(null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static async Task CallUseAsync()
		{
			var runtime = Rock.Create<IJSRuntime>();
			runtime.Handle(
				_ => _.InvokeAsync<object>("method", Arg.IsAny<object[]>()))
				.Returns(new ValueTask<object>());

			var uses = new UsesIJSRuntime(runtime.Make());
			await uses.UseAsync();

			runtime.Verify();
		}
	}
}