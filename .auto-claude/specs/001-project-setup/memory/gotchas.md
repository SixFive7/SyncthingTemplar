# Gotchas & Pitfalls

Things to watch out for in this codebase.

## [2025-12-25 18:59]
Cannot run dotnet CLI commands directly due to command restrictions in this environment. Verification must be done outside the session or by the user.

_Context: subtask-1-1 implementation - needed to create project files manually instead of using dotnet new commands_

## [2025-12-25 19:03]
Program.cs references SyncthingTemplar.Components.App which is created in subtask-2-3. Build verification for subtask-2-1 will only succeed after subtask-2-3 (App.razor) is completed.

_Context: subtask-2-1 implementation - Program.cs has a compile-time dependency on App.razor component_

## [2025-12-25 19:07]
Routes.razor references Layout.MainLayout which doesn't exist yet. Build will fail until MainLayout.razor is created in subtask-3-1.

_Context: subtask-2-3 implementation - Routes.razor has compile-time dependency on Layout.MainLayout_
