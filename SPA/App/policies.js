/**
 * Enter here the user flows and custom policies for your B2C application
 * To learn more about user flows, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/user-flow-overview
 * To learn more about custom policies, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/custom-policy-overview
 */
const b2cPolicies = {
    names: {
        signUpSignIn: "b2c_1a_signin",
        forgotPassword: "b2c_1a_passwordreset",
        editProfile: "b2c_1a_profileedit",
        signup:"b2c_1a_signup",
        verifyEmail: "b2c_1a_verifyemail"
    },
    authorities: {
        signUpSignIn: {
            authority: "https://rallycommunitas.b2clogin.com/rallycommunitas.onmicrosoft.com/b2c_1a_signin",
        },
        forgotPassword: {
            authority: "https://rallycommunitas.b2clogin.com/rallycommunitas.onmicrosoft.com/b2c_1a_passwordreset",
        },
        editProfile: {
            authority: "https://rallycommunitas.b2clogin.com/rallycommunitas.onmicrosoft.com/b2c_1a_profileedit"
        },
        signup: {
            authority: "https://rallycommunitas.b2clogin.com/rallycommunitas.onmicrosoft.com/b2c_1a_signup"
        },
        verifyEmail: {
            authority: "https://rallycommunitas.b2clogin.com/rallycommunitas.onmicrosoft.com/b2c_1a_verifyemail"
        }
    },
    authorityDomain: "rallycommunitas.b2clogin.com"
}