// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace TeamworkSystem.IdentityServer.Quickstart.Consent
{
    public class ConsentViewModel : ConsentInputModel
    {
        public string ClientName { get; set; } = null!;
        public string ClientUrl { get; set; } = null!;
        public string ClientLogoUrl { get; set; } = null!;
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; } = null!;
        public IEnumerable<ScopeViewModel> ApiScopes { get; set; } = null!;
    }
}
