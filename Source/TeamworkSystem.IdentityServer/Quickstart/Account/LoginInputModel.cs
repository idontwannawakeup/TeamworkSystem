// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.IdentityServer.Quickstart.Account
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; } = null!;
    }
}
