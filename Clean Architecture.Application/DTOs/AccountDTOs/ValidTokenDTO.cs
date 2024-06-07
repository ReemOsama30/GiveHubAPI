using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.AccountDTOs
{
    public class ValidTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }


        public ValidTokenDTO(JwtSecurityToken jwtSecurityToken)
        {


            Expiration = jwtSecurityToken.ValidTo;

            WriteToken(jwtSecurityToken);


        }
       
        private void WriteToken (JwtSecurityToken jwtSecurityToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            Token = tokenHandler.WriteToken(jwtSecurityToken);
        }

       
    }
}
