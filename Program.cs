
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Hello, World!");

// Create a payload with some claims
var claims = new[]
{
    new Claim(JwtRegisteredClaimNames.Iss, "Claim1"),
    new Claim(JwtRegisteredClaimNames.Exp, 
        DateTime.Now.AddSeconds(60).ToString()),
    new Claim("admin", "true"),
    new Claim(ClaimTypes.Name, "Claim2"),
};

// Create a security key
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3784ybcny2374tbg764vb8274v62864b864b63b367 83787 738 736877 6"));

// Create a signing credentials
var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

// Create a JWT security token
var token = new JwtSecurityToken(
                issuer: "TheIssuer1",
                audience: "TheAudience1",
                claims: claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: creds);

Console.WriteLine("JWT Token: " + new JwtSecurityTokenHandler().WriteToken(token));

// Decode the token and verify it using the secret key
var tokenHandler = new JwtSecurityTokenHandler();
var validationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = key
};

SecurityToken decodedToken;
ClaimsPrincipal decodedPrincipal = tokenHandler.ValidateToken(
                            new JwtSecurityTokenHandler().WriteToken(token),
                            validationParameters, out decodedToken);

// Write the decoded payload to the console
Console.WriteLine("Decoded Payload: " + decodedPrincipal.Claims);
Console.ReadLine();
