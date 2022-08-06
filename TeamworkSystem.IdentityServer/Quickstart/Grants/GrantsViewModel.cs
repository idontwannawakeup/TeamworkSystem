// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace TeamworkSystem.IdentityServer.Quickstart.Grants
{
    public class GrantsViewModel
    {
        public IEnumerable<GrantViewModel> Grants { get; set; } = null!;
    }

    public class GrantViewModel
    {
        public string ClientId { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string ClientUrl { get; set; } = null!;
        public string ClientLogoUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime? Expires { get; set; }
        public IEnumerable<string> IdentityGrantNames { get; set; } = null!;
        public IEnumerable<string> ApiGrantNames { get; set; } = null!;
    }
}
