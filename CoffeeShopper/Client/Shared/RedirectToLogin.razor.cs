using Microsoft.AspNetCore.Components;


namespace Client.Shared;
public partial class RedirectToLogin
{
    [Inject] public NavigationManager Navigation { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.CompletedTask;
        Navigation.NavigateTo($"/login?redirectUri={Uri.EscapeDataString(Navigation.Uri)}", true);
    }
}
