﻿using JWTAuthServer.Core.Configuration;
using JWTAuthServer.Core.DTOs;
using JWTAuthServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreatetokenByClient(Client client);
    }
}
