using iQurban.CustomAttributes;
using iQurban.Models;
using Microsoft.IdentityModel.Tokens;
//using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iQurban
{
    public class TokenProvider
    {
        public string LoginUser(string UserID, string Password)
        {
            //Get user details for the user who is trying to login
            var user = UserList.SingleOrDefault(x => x.USERID == UserID);

            //Authenticate User, Check if it’s a registered user in Database
            if (user == null)
                return null;

            //If it's registered user, check user password stored in Database 
            //For demo, password is not hashed. Simple string comparison 
            //In real, password would be hashed and stored in DB. Before comparing, hash the password
            if (Password == user.PASSWORD)
            {
                //Authentication successful, Issue Token with user credentials
                //Provide the security key which was given in the JWToken configuration in Startup.cs
                var key = Encoding.ASCII.GetBytes
                          ("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                //Generate Token for user 
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:51036/",
                    audience: "http://localhost:51036/",
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                                        SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }
        //Using hard coded collection list as Data Store for demo purposes
        //In reality, User data comes from Database or other Data Source.
        public List<User> UserList = new List<User>
        {
            new User { USERID = "agung@email.com", PASSWORD = "test",
            EMAILID = "agung@email.com", FIRST_NAME = "Agung",
            LAST_NAME = "Tri Wahyono", PHONE = "000-00000",
            ACCESS_LEVEL = Roles.DIRECTOR.ToString(), WRITE_ACCESS = "WRITE_ACCESS" },
            new User { USERID = "bowo@email.com", PASSWORD = "test",
            FIRST_NAME = "Bowo", LAST_NAME = "Satryo",
            EMAILID = "bowo@email.com", PHONE = "000-00000",
            ACCESS_LEVEL = Roles.SUPERVISOR.ToString(), WRITE_ACCESS = "WRITE_ACCESS" },
            new User { USERID = "raihan@email.com", PASSWORD = "test",
            FIRST_NAME = "Raihan", LAST_NAME = "Zakariya",
            EMAILID = "raihan@email.com", PHONE = "000-00000",
            ACCESS_LEVEL = Roles.ANALYST.ToString(), WRITE_ACCESS = "WRITE_ACCESS" },
            new User { USERID = "rakha@email.com", PASSWORD = "test",
            FIRST_NAME = "Rakha", LAST_NAME = "Nararya",
            EMAILID = "rakha@email.com", PHONE = "000-00000",
            ACCESS_LEVEL = Roles.ANALYST.ToString(), WRITE_ACCESS = "" }
        };

        //Using hard coded values in claims collection list as Data Store for demo. 
        //In reality, User data comes from Database or other Data Source.
        private IEnumerable<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.FIRST_NAME + " " + user.LAST_NAME);
            claims.Add(_claim);
            _claim = new Claim("USERID", user.USERID);
            claims.Add(_claim);
            _claim = new Claim("EMAILID", user.EMAILID);
            claims.Add(_claim);
            _claim = new Claim("PHONE", user.PHONE);
            claims.Add(_claim);
            _claim = new Claim(user.ACCESS_LEVEL, user.ACCESS_LEVEL.ToUpper());
            claims.Add(_claim);
            
            if (user.WRITE_ACCESS != "")
            {
                _claim = new Claim(user.WRITE_ACCESS, user.WRITE_ACCESS);
                claims.Add(_claim);
            }

            return claims.AsEnumerable<Claim>();

        }

        
    }
}
