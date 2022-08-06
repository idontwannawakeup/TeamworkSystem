// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace TeamworkSystem.IdentityServer.Quickstart.Account
{
    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string SignOutIframeUrl { get; set; } = null!;

        public bool AutomaticRedirectAfterSignOut { get; set; }

        public string LogoutId { get; set; } = null!;
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        public string? ExternalAuthenticationScheme { get; set; }
    }
}
