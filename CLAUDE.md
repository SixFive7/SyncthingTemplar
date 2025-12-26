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
