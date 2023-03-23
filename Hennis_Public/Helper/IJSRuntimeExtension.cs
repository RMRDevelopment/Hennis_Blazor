using Microsoft.JSInterop;

namespace Hennis_Public.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ShowStaffImageModal(this IJSRuntime jsRuntime, string message = "")
        {
            await jsRuntime.InvokeVoidAsync("ShowStaffImageModal");
        }

        public static async ValueTask InitShowMore(this IJSRuntime jsRuntime, string message = "")
        {
            await jsRuntime.InvokeVoidAsync("InitShowMoreFunction");
        }
    }
}
