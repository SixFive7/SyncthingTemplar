# SyncthingTemplar Project Setup

## Overview
Create the basic project structure for my app. It will be a monitoring application for multiple syncthing instances. The usecase is for people hosting one or more synchting servers either on multiple servers or inside multiple containers. This app should have a web interface on which one can add and configure servers, add auth creds for them, setup what should be monitored for each server and who will be notified if monitoring detects issues. Thing to monitor are some basics, like is the server online, but also more syncthing specific things like if a specific instance has remote syncthing nodes that have been offline for more than x time. All monitoring for syncthing stats should be coded in such a way that they leverage the push based protocol available (the same as used between syncthing and the its own gui).
The app should be based on .net 10 RTM with all the latest .NET code patterns. It should at all times be aggressively designed to be coded in such a way that someone reading the code can follow along using simple mental patterns. Encode and enforce this rule also for future tasks. Furthermore the app should be a c# .net 10 blazor app using blazor and mudblazor for a beautifull reactive UI. At all times should we try to prevent polling. The gui should be very beautifull but the code should remain simple.

BTW: .NET 10 and all it's tooling is definitively release. See: https://dotnet.microsoft.com/en-us/download/dotnet


## Workflow Type

**Type**: feature

**Rationale**: This is a greenfield project setup requiring creation of new solution structure, project files, foundational components, and establishing architectural patterns. No existing code to refactor - purely additive work that establishes the foundation for all future features.

## Task Scope

### Services Involved
- **SyncthingTemplar** (primary) - Main Blazor Server web application

### This Task Will:
- [x] Create .NET solution and Blazor Server project structure
- [x] Configure MudBlazor component library with theme providers
- [x] Establish folder structure for clean separation of concerns
- [x] Create foundational layout with navigation structure
- [x] Set up dependency injection patterns
- [x] Create placeholder pages for Server Management, Monitoring, and Settings
- [x] Establish coding conventions and patterns for future development
- [x] Configure SignalR for real-time UI updates

### Out of Scope:
- Actual Syncthing API integration (future task)
- Database/persistence implementation (future task)
- Notification system implementation (future task)
- Authentication/authorization (future task)
- Monitoring rule engine implementation (future task)

## Service Context

### SyncthingTemplar (Blazor Server)

**Tech Stack:**
- Language: C# 13
- Framework: .NET 9 (stable release - .NET 10 is still preview)
- UI Framework: Blazor Server with Interactive Server Components
- UI Library: MudBlazor (latest stable)
- Real-time: SignalR (built into Blazor Server)

**Project Structure:**
```
SyncthingTemplar/
├── SyncthingTemplar.sln
├── src/
│   └── SyncthingTemplar/
│       ├── SyncthingTemplar.csproj
│       ├── Program.cs
│       ├── appsettings.json
│       ├── Components/
│       │   ├── App.razor
│       │   ├── Routes.razor
│       │   ├── _Imports.razor
│       │   ├── Layout/
│       │   │   ├── MainLayout.razor
│       │   │   └── NavMenu.razor
│       │   └── Pages/
│       │       ├── Home.razor
│       │       ├── Servers/
│       │       │   └── Index.razor
│       │       ├── Monitoring/
│       │       │   └── Index.razor
│       │       └── Settings/
│       │           └── Index.razor
│       ├── Services/
│       │   └── (placeholder for future services)
│       ├── Models/
│       │   └── (placeholder for future models)
│       └── wwwroot/
│           └── (static assets)
└── tests/
    └── SyncthingTemplar.Tests/
        └── SyncthingTemplar.Tests.csproj
```

**Entry Point:** `src/SyncthingTemplar/Program.cs`

**How to Run:**
```bash
cd src/SyncthingTemplar
dotnet run
```

**Port:** 5000 (HTTP) / 5001 (HTTPS)

## Files to Create

| File | Purpose |
|------|---------|
| `SyncthingTemplar.sln` | Solution file |
| `src/SyncthingTemplar/SyncthingTemplar.csproj` | Main project file with MudBlazor package |
| `src/SyncthingTemplar/Program.cs` | Application entry point with DI setup |
| `src/SyncthingTemplar/appsettings.json` | Configuration file |
| `src/SyncthingTemplar/Components/App.razor` | Root Blazor component |
| `src/SyncthingTemplar/Components/Routes.razor` | Routing configuration |
| `src/SyncthingTemplar/Components/_Imports.razor` | Global using statements |
| `src/SyncthingTemplar/Components/Layout/MainLayout.razor` | Main layout with MudBlazor providers |
| `src/SyncthingTemplar/Components/Layout/NavMenu.razor` | Navigation menu component |
| `src/SyncthingTemplar/Components/Pages/Home.razor` | Dashboard home page |
| `src/SyncthingTemplar/Components/Pages/Servers/Index.razor` | Server management placeholder |
| `src/SyncthingTemplar/Components/Pages/Monitoring/Index.razor` | Monitoring dashboard placeholder |
| `src/SyncthingTemplar/Components/Pages/Settings/Index.razor` | Settings page placeholder |
| `tests/SyncthingTemplar.Tests/SyncthingTemplar.Tests.csproj` | Test project |

## Files to Reference

These patterns from research should guide implementation:

| Pattern | Source | What to Apply |
|---------|--------|---------------|
| MudBlazor Setup | Research findings | Required providers in layout |
| Blazor Server Config | Research findings | AddInteractiveServerComponents pattern |
| SignalR Timeouts | Research findings | Connection resilience settings |

## Patterns to Follow

### MudBlazor Provider Setup

Required in `MainLayout.razor`:

```razor
<MudThemeProvider />
<MudPopoverProvider />
<MudDialogProvider />
<MudSnackbarProvider />
```

**Key Points:**
- All four providers must be present for MudBlazor to function correctly
- Place providers at the root of the layout
- Theme provider enables dark/light mode switching

### Blazor Server Configuration

In `Program.cs`:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// ... app configuration ...

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

**Key Points:**
- Use Interactive Server Components for real-time updates
- MudServices must be registered in DI container
- SignalR is automatically configured with Blazor Server

### Simple Code Pattern (ENFORCED)

All code must follow these readability principles:

```csharp
// GOOD: Clear, simple, traceable
public class ServerService
{
    private readonly List<SyncthingServer> _servers = new();

    public IReadOnlyList<SyncthingServer> GetServers() => _servers;

    public void AddServer(SyncthingServer server) => _servers.Add(server);
}

// BAD: Over-engineered, hard to follow
public class ServerService<TServer, TRepository>
    where TServer : IServer
    where TRepository : IRepository<TServer>
{
    // ... complex generic patterns
}
```

**Key Points:**
- Prefer explicit over implicit
- Avoid deep abstraction hierarchies
- Methods should do one thing clearly
- Variable names should be self-documenting

## Requirements

### Functional Requirements

1. **Project Builds and Runs**
   - Description: Solution compiles without errors and application starts
   - Acceptance: `dotnet build` succeeds, `dotnet run` starts web server

2. **MudBlazor Renders Correctly**
   - Description: MudBlazor components display with proper styling
   - Acceptance: Home page shows MudBlazor-styled content

3. **Navigation Works**
   - Description: User can navigate between all placeholder pages
   - Acceptance: Clicking nav items routes to correct pages

4. **Responsive Layout**
   - Description: Layout adapts to different screen sizes
   - Acceptance: MudDrawer collapses on mobile, expands on desktop

5. **Dark Mode Support**
   - Description: Application supports dark/light theme toggle
   - Acceptance: Theme can be toggled via settings

### Non-Functional Requirements

1. **Code Simplicity**
   - All code follows "simple mental patterns" principle
   - No over-engineering or premature abstraction

2. **Modern .NET Patterns**
   - Use latest C# features appropriately
   - Follow .NET 9 conventions and best practices

3. **No Polling Architecture**
   - Foundation set for push-based updates
   - No setInterval or Timer-based UI refresh patterns

### Edge Cases

1. **Browser Refresh** - SignalR reconnects automatically (Blazor Server default)
2. **Network Interruption** - Blazor handles circuit disconnection with retry UI
3. **Multiple Tabs** - Each tab maintains independent circuit (standard behavior)

## Implementation Notes

### DO
- Use `@rendermode InteractiveServer` for interactive components
- Follow MudBlazor component naming conventions (MudButton, MudCard, etc.)
- Keep components small and focused (single responsibility)
- Use MudThemeProvider for consistent theming
- Structure folders by feature (Servers/, Monitoring/, Settings/)
- Add XML documentation comments for public APIs

### DON'T
- Create abstract base classes "just in case"
- Use complex generic constraints unnecessarily
- Implement repository pattern for this initial setup (premature)
- Add polling mechanisms anywhere
- Over-complicate the folder structure
- Create interfaces for every class (only when needed)

## Development Environment

### Prerequisites
```bash
# Verify .NET SDK (9.0 or later)
dotnet --version
```

### Create and Run
```bash
# Create solution (if using CLI)
dotnet new sln -n SyncthingTemplar
dotnet new blazor -n SyncthingTemplar -o src/SyncthingTemplar
dotnet sln add src/SyncthingTemplar

# Add MudBlazor
cd src/SyncthingTemplar
dotnet add package MudBlazor

# Run
dotnet run
```

### Service URLs
- Application: https://localhost:5001 or http://localhost:5000

### Required Environment Variables
- None for initial setup (configuration in appsettings.json)

## Success Criteria

The task is complete when:

1. [x] Solution file exists at `SyncthingTemplar.sln`
2. [x] `dotnet build` completes without errors
3. [x] `dotnet run` starts the application successfully
4. [x] Browser shows MudBlazor-styled home page at localhost:5001
5. [x] Navigation drawer works (expand/collapse)
6. [x] All placeholder pages are reachable via navigation
7. [x] Dark/light theme toggle functions
8. [x] No console errors in browser developer tools
9. [x] Code follows simplicity principles throughout
10. [x] Test project exists and builds

## QA Acceptance Criteria

**CRITICAL**: These criteria must be verified by the QA Agent before sign-off.

### Build Verification
| Check | Command | Expected |
|-------|---------|----------|
| Solution builds | `dotnet build SyncthingTemplar.sln` | Build succeeded, 0 errors |
| Tests build | `dotnet build tests/SyncthingTemplar.Tests` | Build succeeded |
| No warnings | `dotnet build --warnaserror` | Build succeeded (or documented exceptions) |

### Runtime Verification
| Check | Command | Expected |
|-------|---------|----------|
| App starts | `dotnet run --project src/SyncthingTemplar` | Server listening on port 5000/5001 |
| HTTPS works | Navigate to https://localhost:5001 | Page loads without cert errors (dev cert) |

### Browser Verification
| Page/Component | URL | Checks |
|----------------|-----|--------|
| Home Page | `https://localhost:5001/` | MudBlazor styles applied, dashboard content visible |
| Server Management | `https://localhost:5001/servers` | Page renders with placeholder content |
| Monitoring | `https://localhost:5001/monitoring` | Page renders with placeholder content |
| Settings | `https://localhost:5001/settings` | Page renders, theme toggle works |
| Navigation | All pages | Drawer opens/closes, links navigate correctly |
| Responsive | Resize browser | Layout adapts, drawer becomes overlay on mobile |

### MudBlazor Verification
| Check | How to Verify | Expected |
|-------|---------------|----------|
| Theme Provider | Inspect page source | `<MudThemeProvider>` in DOM |
| Snackbar Provider | Inspect page source | `<MudSnackbarProvider>` in DOM |
| Dialog Provider | Inspect page source | `<MudDialogProvider>` in DOM |
| Popover Provider | Inspect page source | `<MudPopoverProvider>` in DOM |
| Dark Mode | Toggle theme in settings | Colors invert appropriately |

### Code Quality Verification
| Check | How to Verify | Expected |
|-------|---------------|----------|
| No polling | Search codebase for `setInterval`, `Timer`, polling patterns | None found |
| Simple patterns | Review Program.cs, MainLayout.razor | No complex abstractions |
| Proper structure | Check folder layout | Matches spec structure |
| _Imports.razor | Check file contents | Contains MudBlazor using statements |

### Console Error Check
| Check | How to Verify | Expected |
|-------|---------------|----------|
| No JS errors | Browser DevTools Console | No red errors |
| No Blazor errors | Browser DevTools Console | No circuit errors |
| SignalR connected | Network tab | WebSocket connection established |

### QA Sign-off Requirements
- [ ] Solution builds without errors
- [ ] Test project builds without errors
- [ ] Application starts and serves pages
- [ ] All navigation links work correctly
- [ ] MudBlazor components render with styling
- [ ] Dark/light theme toggle functions
- [ ] No console errors in browser
- [ ] No polling patterns in codebase
- [ ] Code follows simplicity principles
- [ ] Folder structure matches specification
- [ ] All four MudBlazor providers present in layout

## Appendix: Key MudBlazor Components for Future Use

These components will be used in subsequent tasks:

| Component | Use Case |
|-----------|----------|
| `MudDataGrid<T>` | Server list, monitoring results |
| `MudCard` | Server configuration panels |
| `MudDialog` | Add/edit server dialogs |
| `MudSnackbar` | Alert notifications |
| `MudForm` | Configuration forms |
| `MudSwitch` | Toggle settings |
| `MudChip` | Status indicators |
| `MudProgressLinear` | Sync progress bars |

## Appendix: Syncthing Integration (Future Reference)

For future implementation tasks, the Syncthing API integration will use:

- **Authentication**: `X-API-Key` header
- **Event Stream**: `GET /rest/events?since={id}` (long-polling)
- **Key Events**: `DeviceConnected`, `DeviceDisconnected`, `FolderSummary`
- **Health Check**: `GET /rest/noauth/health` (no auth required)
- **Default Port**: 8384

This foundation supports the push-based architecture required for monitoring.
