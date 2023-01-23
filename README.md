This example shows how to create a JWT token using the System.IdentityModel.Tokens.Jwt library, and how to encode and decode a token using the HS256 algorithm and a secret key. The payload in this example contains claims such as an expiration time, custom claims and an issuer. The encoded token and the decoded payload are printed to the console for the engineer to view.

Please note that in real-world scenarios, you should use a secure way to store and transmit the secret key and also use stronger algorithms like HS256, HS512, RS256, etc.




### Implementation
This example uses the JwtSecurityTokenHandler class to create and validate a JWT.

In the Main method, we first create a SymmetricSecurityKey object with a secret key, this key will be used to sign the JWT.

Then we create a SecurityTokenDescriptor object that contains the claims for the token. This descriptor includes the subject's name and role, an expiration time, and the signing credentials.

We then create the token by passing the descriptor to the JwtSecurityTokenHandler and print it to the console.

After that, we set up the TokenValidationParameters object to validate the token, this includes the secret key, clock skew, issuer and audience validation.

Finally, we use the ValidateToken method to validate the token and check if it is valid or not.

This is a basic example, it's important to note that in production, you need to handle token expiration and refresh token, and validate the token on the server side.

You can also use third-party libraries such as JWT.io, or IdentityServer to handle token generation, validation and expiration.