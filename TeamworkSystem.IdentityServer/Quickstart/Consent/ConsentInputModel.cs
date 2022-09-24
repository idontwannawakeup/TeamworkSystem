// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace TeamworkSystem.IdentityServer.Quickstart.Consent
{
    public class ConsentInputModel
    {
        public string Button { get; set; } = null!;
        public IEnumerable<string> ScopesConsented { get; set; } = null!;
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; } = null!;
        public string? Description { get; set; }
    }
}
