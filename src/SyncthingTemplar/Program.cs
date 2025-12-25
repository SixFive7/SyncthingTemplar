// SyncthingTemplar - Syncthing Monitoring Application
// Entry point configuring Blazor Server with MudBlazor UI components.

using MudBlazor.Services;
using SyncthingTemplar.Components;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor Server components with interactive server-side rendering
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add MudBlazor UI component library services
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map Blazor components with interactive server-side rendering
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
