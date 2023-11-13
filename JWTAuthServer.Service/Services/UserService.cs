﻿using JWTAuthServer.Core.DTOs;
using JWTAuthServer.Core.Models;
using JWTAuthServer.Core.Services;
using JWTAuthServer.Service.Mapping;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user= new UserApp { Email = createUserDto.Email,UserName=createUserDto.Username };

            var result=await _userManager.CreateAsync(user,createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> GetUserByNameAsync(string name)
        {
            var user= await _userManager.FindByNameAsync(name);
            if (user==null)
            {
                return Response<UserAppDto>.Fail("Username not found", 404, true);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
