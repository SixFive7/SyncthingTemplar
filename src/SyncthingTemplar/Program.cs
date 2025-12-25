// SyncthingTemplar - Syncthing Monitoring Application
// This is a minimal entry point to enable build verification.
// Full implementation with Blazor Server and MudBlazor will be added in subsequent subtasks.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "SyncthingTemplar - Under Construction");

app.Run();
