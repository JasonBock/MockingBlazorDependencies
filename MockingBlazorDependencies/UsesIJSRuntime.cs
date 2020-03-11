using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MockingBlazorDependencies
{
	public sealed class UsesIJSRuntime
	{
		private readonly IJSRuntime runtime;

		public UsesIJSRuntime(IJSRuntime runtime) =>
			this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));

		public async Task UseAsync() =>
			await this.runtime.InvokeVoidAsync("method", 2, "value");
	}
}