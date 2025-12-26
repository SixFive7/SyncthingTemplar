# Browser Testing with Chrome DevTools MCP

When working on web UI features or debugging ASP.NET web pages:

1. **Self-test first** - Use the `chrome-devtools` MCP server to verify changes before asking the user to test
2. Navigate to the local development URL and take snapshots to verify UI state
3. Check console messages for errors
4. Monitor network requests for API issues
5. Only fall back to asking the user when:
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
