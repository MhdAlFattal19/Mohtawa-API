using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Mohtawa.Application.Helpers;
using Mohtawa.Domain.Contracts;
using Mohtawa.Domain.DTOs;
using Mohtawa.Domain.Enums;
using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mohtawa.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IMapper _mapper;
        private readonly IResponseHelper _responseHelper;

        public AuthService(JwtTokenConfig jwtTokenConfig,
            IMapper mapper, IResponseHelper responseHelper)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _mapper = mapper;
            _responseHelper = responseHelper;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            // to do  validate login request

            // to do add user service
            //var user = await _userManager.GetUserByEmailAsync(request.Email);

            var userId = "d4r6b3c3-e056-46a5-976b-21cb61c138c4";

            return new LoginResponse
            {
                Data = new LoginDTO
                {
                    AccessToken = GenerateToken(userId),
                },
                MessageDTOs = new List<MessageDTO>
                {
                    new MessageDTO
                    {
                        Message = "Login successfully"
                    }
                },
                Status = (int)APIResponseEnum.Success,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        #region Private Methods
        private string GenerateToken(string userId)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.AccessTokenExpiration);
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("user_Id", userId, ClaimValueTypes.String));



            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: _jwtTokenConfig.Issuer,
                        audience: _jwtTokenConfig.Audience,
                        subject: claimsIdentity,
                        notBefore: issuedAt,
                        expires: expires,
                        signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        #endregion
    }

}
