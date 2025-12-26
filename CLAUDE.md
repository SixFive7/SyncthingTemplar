# Simplicity First

Prefer solutions with the simplest mental model to ensure beginner-friendly code:

1. **Favor clarity over cleverness** - Choose straightforward implementations over complex abstractions
2. **Minimize cognitive load** - Reduce the number of concepts a reader must understand
3. **Explicit over implicit** - Make behavior obvious rather than relying on hidden conventions
4. **Flat over nested** - Prefer simple control flow; avoid deep nesting and indirection
5. **Document the "why"** - When complexity is unavoidable, explain the reasoning


# Modern Standards and Patterns

Always follow the most recent coding frameworks, standards, patterns, and file formats:

1. **Detect and upgrade** - When encountering outdated patterns, upgrade them in place
2. **Prefer modern syntax** - Use current language features and idioms
3. **Use current file formats** - Prefer modern project formats (e.g., SDK-style .csproj, .slnx)


# Package Version Policy

Always use the latest stable versions of packages:

1. **Upgrade on detection** - When outdated package versions are detected, upgrade them in place
2. **Check compatibility** - Ensure upgrades don't break existing functionality
3. **Prefer stable releases** - Use latest stable versions, not prereleases, unless specifically requested


# Browser Testing with Chrome DevTools MCP

When working on web UI features or debugging ASP.NET web pages:

1. **Use subtasks for browser testing** - Browser interactions are context-hungry; spawn a subtask with a fresh context to perform web testing whenever possible
2. **Self-test first** - Use the `chrome-devtools` MCP server to verify changes before asking the user to test
3. Navigate to the local development URL and take snapshots to verify UI state
4. Check console messages for errors
5. Monitor network requests for API issues
6. Only fall back to asking the user when:
   - The MCP server is unavailable
   - You need user credentials or authentication
   - Visual verification requires human judgment
   - The issue cannot be reproduced programmatically


# Windows `nul` File Prevention

PowerShell/Windows commands can accidentally create a `nul` file (Windows NUL device artifact). Follow these rules strictly:

1. **Prevention** - Avoid redirecting output to `nul` in PowerShell; use `$null` or `Out-Null` instead
2. **On sight** - If you ever spot a `nul` file in the working directory, delete it immediately with `rm -f nul`
3. **Before commits** - Always check for and remove any `nul` file before staging/committing: `rm -f nul`
4. **Never commit** - The `nul` file must never be committed to the repository